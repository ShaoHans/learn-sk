using LearnSk.Samples;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System.Reflection;

var builder = Host.CreateApplicationBuilder(args);
// 由于Azure OpenAI的配置信息属于机密，在开源项目中往往使用机密文件管理，
// 它会在本地的某个目录下生成secrets.json，你只需要把机密的配置信息写在这个文件中，
// 它会覆盖appsettings.json文件中相同key的配置
// 参考文件：https://zhuanlan.zhihu.com/p/252241845
// secrets.json文件的目录：C:\Users\[用户名]\AppData\Roaming\Microsoft\UserSecrets\[UserSecretsId]
builder.Configuration.AddUserSecrets<Program>();

// 访问AzureOpenAI服务有可能遇到证书问题，需要使用自己注入的HttpClient()避免证书问题
builder.Services.AddHttpClient();
builder.Services.AddAzureOpenAI();
builder.Services.AddKeyedServices<ISampleService>(Assembly.GetExecutingAssembly());

var host = builder.Build();

var sampleService = host.Services.GetRequiredKeyedService<ISampleService>(nameof(S01_GettingStarted));
await sampleService.RunAsync();

await host.RunAsync();

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.SemanticKernel;

var builder = Host.CreateApplicationBuilder(args);
// 由于Azure OpenAI的配置信息属于机密，在开源项目中往往使用机密文件secrets.json管理，它会覆盖appsettings.json文件中的配置
// 参考文件：https://zhuanlan.zhihu.com/p/252241845
// secrets.json文件的目录：C:\Users\[用户名]\AppData\Roaming\Microsoft\UserSecrets\[UserSecretsId]
builder.Configuration.AddUserSecrets<Program>();

// 访问AzureOpenAI服务有可能遇到证书问题，需要使用自己注入的HttpClient()避免证书问题
builder.Services.AddHttpClient();
builder.Services.AddAzureOpenAI();

var host = builder.Build();

var kernel = host.Services.GetRequiredService<Kernel>();
var result = await kernel.InvokePromptAsync("天空是什么颜色");
Console.WriteLine(result);

await host.RunAsync();

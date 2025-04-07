using System.ClientModel;
using Microsoft.SemanticKernel;
using OpenAI;

Console.WriteLine("请输入apikey：");
var apikey = Console.ReadLine();

var builder = Kernel.CreateBuilder();
var options = new OpenAIClientOptions()
{
    Endpoint = new Uri("https://open.bigmodel.cn/api/paas/v4/")
};

var openAIClient = new OpenAIClient(new ApiKeyCredential(apikey!), options);
builder.AddOpenAIChatCompletion(modelId: "glm-4-flash", openAIClient: openAIClient);
var kernel = builder.Build();
var response = await kernel.InvokePromptAsync("你是谁？");
Console.WriteLine(response.ToString());

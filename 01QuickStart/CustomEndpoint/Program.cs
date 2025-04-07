using Microsoft.SemanticKernel;

var builder = Kernel.CreateBuilder();
#pragma warning disable SKEXP0010 // 类型仅用于评估，在将来的更新中可能会被更改或删除。取消此诊断以继续。
Console.WriteLine("请输入API密钥：");
var apiKey = Console.ReadLine();
builder.AddOpenAIChatCompletion(
    modelId: "glm-4-flash",
    apiKey: apiKey,
    endpoint: new Uri("https://open.bigmodel.cn/api/paas/v4/")
);

var kernel = builder.Build();
var response = await kernel.InvokePromptAsync("你是谁？");
Console.WriteLine(response.ToString());

#pragma warning restore SKEXP0010 // 类型仅用于评估，在将来的更新中可能会被更改或删除。取消此诊断以继续。

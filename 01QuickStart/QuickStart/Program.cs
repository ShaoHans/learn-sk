using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

var builder = Kernel.CreateBuilder();
builder.AddAzureOpenAIChatCompletion("test01", "https://shaohanzhongopenaidemo.openai.azure.com/", "");
builder.Services.AddLogging(services => services.AddConsole().SetMinimumLevel(LogLevel.Trace));

Kernel kernel = builder.Build();
kernel.Plugins.AddFromType<LightsPlugin>();
var settings = new OpenAIPromptExecutionSettings()
{
    ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
};
var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

var history = new ChatHistory();

var result = await chatCompletionService.GetChatMessageContentAsync(history, settings, kernel);

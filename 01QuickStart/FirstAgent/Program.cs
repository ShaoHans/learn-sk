
using FirstAgent;

using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

var builder = Kernel.CreateBuilder();
builder.AddAzureOpenAIChatCompletion("test01", "https://shaohanzhongopenaidemo.openai.azure.com/", "");
builder.Plugins.AddFromType<EmailPlugin>();
var kernel = builder.Build();

// Enable planning
OpenAIPromptExecutionSettings openAIPromptExecutionSettings = new()
{
    ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
};

var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

//// Create chat history
//var history = new ChatHistory();
//history.AddUserMessage("Can you help me write an email for my boss?");

//// Get the response from the AI
//var result = await chatCompletionService.GetChatMessageContentAsync(
//    history,
//    executionSettings: openAIPromptExecutionSettings,
//    kernel: kernel
//);

//foreach (var item in result.Items)
//{
//    Console.WriteLine(((TextContent)item).Text);
//}

//Console.ReadLine();

// Create the chat history
var chatMessages = new ChatHistory("""
    You are a friendly assistant who likes to follow the rules. You will complete required steps
    and request approval before taking any consequential actions. If the user doesn't provide
    enough information for you to complete a task, you will keep asking questions until you have
    enough information to complete the task.
    """);

// Start the conversation
while (true)
{
    // Get user input
    Console.Write("User > ");
    chatMessages.AddUserMessage(Console.ReadLine()!);

    var result = chatCompletionService.GetStreamingChatMessageContentsAsync(
        chatMessages,
        executionSettings: openAIPromptExecutionSettings,
        kernel: kernel);

    // Stream the results
    string fullMessage = "";
    Console.Write("Assistant > ");

    await foreach (var content in result)
    {
        Console.Write(content.Content);
        fullMessage += content.Content;
    }
    Console.WriteLine();

    // Add the message from the agent to the chat history
    chatMessages.AddAssistantMessage(fullMessage);
}
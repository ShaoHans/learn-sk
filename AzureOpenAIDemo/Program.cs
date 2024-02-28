// See https://aka.ms/new-console-template for more information
using AzureOpenAIDemo;

using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;

var key = "";
var endpoint = "";
var kernel = Kernel.CreateBuilder()
    .AddAzureOpenAIChatCompletion(
        deploymentName: "test01",
        endpoint: endpoint,
        apiKey: key
    )
    .Build();

var timePlugin = new TimePlugin();

kernel.ImportPluginFromObject(timePlugin, "time");

const string promptTemplate = @"
Today is: {{time.Date}}
Current time is: {{time.Time}}

Answer to the following questions using JSON syntax, including the data used.
Is it morning, afternoon, evening, or night (morning/afternoon/evening/night)?
Is it weekend time (weekend/not weekend)?
";

// This allows to see the prompt before it's sent to OpenAI
//Console.WriteLine("--- Rendered Prompt");
//var promptRenderer = new BasicPromptTemplateEngine();
//var renderedPrompt = await promptRenderer.RenderAsync(FunctionDefinition, kernel.CreateNewContext());
//Console.WriteLine(renderedPrompt);

// Run the prompt / semantic function
//var kindOfDay = kernel.CreateSemanticFunction(FunctionDefinition, new OpenAIRequestSettings() { MaxTokens = 100 });
var func = kernel.CreateFunctionFromPrompt(promptTemplate, new OpenAIPromptExecutionSettings
{
    MaxTokens = 100
});

// Show the result
Console.WriteLine("--- Semantic Function result");
var result = await kernel.InvokeAsync(func);
Console.WriteLine(result.GetValue<string>());


﻿using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Orchestration;
using Microsoft.SemanticKernel.SemanticFunctions;

namespace Common;

public class OpenAI
{
    public static string GetApiKey(string envVariableName = "OPENAI_API_KEY")
    {
        var key = Environment.GetEnvironmentVariable(envVariableName);
        if(string.IsNullOrEmpty(key))
        {
            Console.WriteLine("please input your OpenAI Api Key ...");
            key = Console.ReadLine();
        }
        return key;
    }

    public static async Task<SKContext> GetTextCompletionAsync(OpenAIConfig config)
    {
        var apiKey = GetApiKey(config.EnvVariableName);
        var kernel = Kernel.Builder.Build();
        kernel.Config.AddOpenAITextCompletionService(config.ModelId, apiKey);
        var promptTemplate = new PromptTemplate(config.Template, config.PromptTemplateConfig, kernel);
        var funcConfig = new SemanticFunctionConfig(config.PromptTemplateConfig, promptTemplate);
        var func = kernel.RegisterSemanticFunction(config.SkillName, config.FunctionName, funcConfig);
        return await kernel.RunAsync(config.Input, func);
    }

    public static void Output(OpenAIConfig config, SKContext context)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Prompt：");
        Console.WriteLine(config.Template);
        Console.WriteLine("============================================");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Input：");
        Console.WriteLine(config.Input);
        Console.WriteLine("============================================");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Output：");
        Console.WriteLine(context);
    }
}
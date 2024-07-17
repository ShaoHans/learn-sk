using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace LearnSk.Samples;

public class S01_GettingStarted : ISampleService
{
    private readonly Kernel _kernel;

    public S01_GettingStarted(Kernel kernel)
    {
        _kernel = kernel;
    }

    public async Task RunAsync()
    {
        var result = await _kernel.InvokePromptAsync("Semantic Kernel 是什么？");
        Console.WriteLine(result);
        Console.WriteLine("========================================================");

        var arguments = new KernelArguments()
        {
            { "CodeLanguage", "C#" }
        };
        await foreach (var r in _kernel.InvokePromptStreamingAsync("介绍一下编程语言{{$CodeLanguage}}的发展历史", arguments))
        {
            Console.Write(r);
        }
        Console.WriteLine("========================================================");

        var arguments2 = new KernelArguments
        (
            new OpenAIPromptExecutionSettings
            {
                MaxTokens = 500,
                Temperature = 0.5
            }
        )
        {
            { "topic", "老虎" }
        };

        Console.WriteLine(await _kernel.InvokePromptAsync("讲一个关于{{$topic}}的笑话", arguments2));
        Console.WriteLine("========================================================");
    }
}

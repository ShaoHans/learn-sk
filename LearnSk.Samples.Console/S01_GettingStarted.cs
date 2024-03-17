using Microsoft.SemanticKernel;

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
            { "CodeLanguage","C#"}
        };
        result = await _kernel.InvokePromptAsync("介绍一下编程语言{{$CodeLanguage}}的发展历史", arguments);
        Console.WriteLine(result);
        Console.WriteLine("========================================================");
    }
}

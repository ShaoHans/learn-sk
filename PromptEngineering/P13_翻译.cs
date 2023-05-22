using Common;

namespace PromptEngineering;

internal class P13_翻译 : IPromptRunner
{
    public async Task RunAsync()
    {
        var config = new OpenAIConfig
        {
            Template = @"请将<div>标签内的内容翻译成英语、俄语和法语。
<div>{{$Input}}</div>",
            Input = "C#是一门非常优美的编程语言"
        };

        var response = await OpenAI.GetTextCompletionAsync(config);
        OpenAI.Output(config, response);
    }
}

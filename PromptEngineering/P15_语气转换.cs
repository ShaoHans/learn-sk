using Common;

namespace PromptEngineering;

internal class P15_语气转换 : IPromptRunner
{
    public async Task RunAsync()
    {
        var config = new OpenAIConfig
        {
            Template = @"请将<div>标签内的内容转成商务信函。
<div>{{$Input}}</div>",

            Input = @"我是工程师，公司生产电子产品，这是我们公司的产品，欢迎咨询"
        };

        var response = await OpenAI.GetTextCompletionAsync(config);
        OpenAI.Output(config, response);
    }
}

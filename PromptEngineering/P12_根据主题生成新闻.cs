using Common;

namespace PromptEngineering;

internal class P12_根据主题生成新闻 : IPromptRunner
{
    public async Task RunAsync()
    {
        var config = new OpenAIConfig
        {
            Template = @"'''分隔符内是一组主题，请根据这些主题生成100字左右的新闻。
主题：'''{{$INPUT}}'''",

            Input = @"美国，欧洲，中国，经济增长，经济复苏，多边主义"
        };

        var response = await OpenAI.GetTextCompletionAsync(config);
        OpenAI.Output(config, response);
    }
}

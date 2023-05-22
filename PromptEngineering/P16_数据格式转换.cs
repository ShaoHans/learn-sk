using Common;

namespace PromptEngineering;

internal class P16_数据格式转换 : IPromptRunner
{
    public async Task RunAsync()
    {
        var data = new[]
        {
            new{ Name="张三",Email="zhangsan@qq.com"},
            new{ Name="李四",Email="lisi@qq.com"},
            new{ Name="王五",Email="wangwu@qq.com"}
        };

        var config = new OpenAIConfig
        {
            Template = @"请将【】标签内的json格式数据转成html。
【{{$Input}}】",

            Input = System.Text.Json.JsonSerializer.Serialize(data)
        };

        var response = await OpenAI.GetTextCompletionAsync(config);
        OpenAI.Output(config, response);
    }
}

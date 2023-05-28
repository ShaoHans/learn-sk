using Common;

namespace PromptEngineering;

internal class P17_纠错 : IPromptRunner
{
    public async Task RunAsync()
    {
        var config = new OpenAIConfig
        {
            Template = @"请对【】标签内每一句话进行语法检查错，如果是病句，请输出正确的语句，如果不是病句就输出“完美语句”
【{{$Input}}】",

            Input = @"1.每个小学生都应该上课专心听讲的好习惯。
2.上课时，始终专心听讲，因此，成绩很好。
3.我的作业全部做完了。
4.老师耐心学生。
5.这次的运动会取得了第一名。
6.我肚子饿了，很想吃。
7.攻无不克，战吴不胜。
8.这个“南”字的拼音是“lan”。"
        };

        var response = await OpenAI.GetTextCompletionAsync(config);
        OpenAI.Output(config, response);
    }
}

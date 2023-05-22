using Common;

namespace PromptEngineering;

internal class P14_语言识别 : IPromptRunner
{
    public async Task RunAsync()
    {
        var config = new OpenAIConfig
        {
            Template = @"请识别<div>标签内每句话的语言，并将它翻译成英语，使用json格式输出，输出为对象数组，每个对象的key为'原语言'、'语种'、'翻译'。
<div>{{$Input}}</div>",

            Input = @"La performance du système est plus lente que d'habitude.
              Mi monitor tiene píxeles que no se iluminan.
              Il mio mouse non funziona.
              Mój klawisz Ctrl jest zepsuty.
              我的屏幕在闪烁."
        };

        var response = await OpenAI.GetTextCompletionAsync(config);
        OpenAI.Output(config, response);
    }
}

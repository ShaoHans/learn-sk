using Common;

namespace PromptEngineering;

internal class P02_结构化输出 : IPromptRunner
{
    public async Task RunAsync()
    {
        var config = new OpenAIConfig
        {
            Template = "推荐.Net框架在欧美最受欢迎的三本书，包含书的英文名、中文名、作者、页数，按照json格式输出，json的key为：name、zhName、author、pages"
        };

        var response = await OpenAI.GetTextCompletionAsync(config);
        Console.WriteLine(config.Template);
        Console.WriteLine(config.Input);
        Console.WriteLine(response);
    }
}

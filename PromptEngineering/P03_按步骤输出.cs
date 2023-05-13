using Common;

namespace PromptEngineering;

internal class P03_按步骤输出 : IPromptRunner
{
    public async Task RunAsync()
    {
        var config = new OpenAIConfig
        {
            Template = @"请将<tag>标签内的文本内容进行处理。
                        如果文本内容包含一系列的步骤说明，请按照给出的格式进行重写，格式如下：
                        步骤1 - …
                        步骤2 - …
                        …
                        步骤N - …
                        如果文本内容不包含一系列步骤，请输出：无法提供步骤说明
    
                        文本内容如下：
                        <tag>{{$INPUT}}</tag>",

            //Input= @"古丝绸之路上的驼队经由中亚沟通中国与欧洲的货物人文时，一定无法想象，
            //        有朝一日“钢铁驼队”会在亚欧大陆上高速往来，输送数量巨大种类繁多的商品物资。"

            Input = @"首先，先将水煮沸，以滚水温壶，再放入茶叶，并倒入能淹过茶叶的水量后，
                盖上壶盖等待约10秒，让茶叶吸收到适量的水分，以利后续茶汤滋味的释放，即可将茶汤倒掉。 
                但并非所有茶叶都需要温润泡，因此根据茶叶种类的不同，也可以选择跳过此步骤。"
        };

        var response = await OpenAI.GetTextCompletionAsync(config);
        OpenAI.Output(config, response);
    }
}

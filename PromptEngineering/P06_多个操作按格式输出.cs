using Common;

namespace PromptEngineering;

public class P06_多个操作按格式输出 : IPromptRunner
{
    public async Task RunAsync()
    {
        var config = new OpenAIConfig
        {
            Template = @"请执行以下操作：
1.使用一句话对```分隔符中的内容进行总结
2.将总结得出的内容翻译成英文
3.列出英文总结中出现的英文名字
4.使用json格式输出英文名字的得分，key为：name,score

使用以下格式输出：
Input：【输入的内容】
总结：【总结】
翻译：【对总结的翻译】
日期：【出现的日期】
名字：【中文总结中出现的名字】
Json：【json数据】

```{{$INPUT}}```",

            Input = @"北京时间5月15日，凯尔特人在抢七大战中以112比88大胜76人，凯尔特人大比分4比3淘汰76人晋级NBA东部决赛。
这场比赛76人只打了一节好球。首节比赛塔克成为奇兵，他命中3记三分单节砍下11分，帮助76人领先6分结束第一节。第二节凯尔特人在塔图姆和布朗的带领下大举反攻，半场结束时，凯尔特人领先76人3分。
第三节，塔图姆彻底统治比赛，他单节三分球5中4高效轰下17分，而76人进攻连连受挫，全队崩盘单节只得到10分。三节战罢，76人落后26分。最后一节凯尔特人很快将分差拉大到30分以上，奠定胜局。"
        };

        var response = await OpenAI.GetTextCompletionAsync(config);
        OpenAI.Output(config, response);
    }
}

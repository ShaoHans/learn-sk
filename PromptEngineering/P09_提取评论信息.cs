using Common;

namespace PromptEngineering;

internal class P09_提取评论信息 : IPromptRunner
{
    public async Task RunAsync()
    {
        var config = new OpenAIConfig
        {
            Template = @"请根据<tag>标签的评论内容提取出相关信息，用于向手机定价部门反馈，控制在10个字符左右。
            这是评论内容：<tag>{{$INPUT}}</tag>",

            Input = @"快递收到，京东自营的物流速度真是没的说，手机到手使用了2天才来评价的，
拿在手里比我别的品牌要轻巧一点，这里最好的一点就是防止小孩子玩手机的模式做的挺好的，
我这个主要是用来给她上网课的，运行速度跟几千的比起来肯定是有很大的差距的。拍照的效果还是可以的，
电池的话基本上一天一次就够了。声音不是特别的大，也够用，价格也才1500多，个人觉得现在荣耀不是以前的荣耀了，整体来说有点虚高了。"
        };

        var response = await OpenAI.GetTextCompletionAsync(config);
        OpenAI.Output(config, response);
    }
}

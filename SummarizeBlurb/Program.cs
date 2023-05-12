using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Orchestration;
using Microsoft.SemanticKernel.SemanticFunctions;

namespace SummarizeBlurb;

internal class Program
{
    static async Task Main(string[] args)
    {
        await Console.Out.WriteLineAsync("please input your OpenAI key ...");
        var key = Console.ReadLine();

        var sk = Kernel.Builder.Build();
        sk.Config.AddOpenAITextCompletionService( "text-davinci-003", key!);
        var context = new ContextVariables();
        context.Set("input", @"从“五一”的预订量看我们有95%左右的入住预订率，随着“五一”节临近，商务客比例在往下走，
                家庭出行、旅游观光的客人比例在上涨。还有个客群变化亮点是文艺活动增多，一有文艺节演出，
                这些文艺团队和观看观众在这边的入住率相对比例也在慢慢上升。
                除了市区酒店，也有不少消费者会选择位于上海市郊的特色民宿，希望在繁忙的日常节奏里找寻自然生活的轻松闲适。
                记者从上海市统计局了解到，今年一季度上海服务零售实现较快增长，1-3月，住宿和餐饮业实现零售额362.54亿元，增长14.3%。");

        var skill = sk.ImportSemanticSkillFromDirectory("MySkills", "TestSkill");
        var skContext  = await sk.RunAsync(context, skill["Summarize"]);
        Console.WriteLine(skContext.Result);

        await Test1(sk);
        await Test2(sk);
    }

    static async Task Test1(IKernel sk)
    {
        string summarizeBlurbFlex = """
            请使用两句话总结以下内容. 
            ---开始内容---
            {{$INPUT}}
            ---结束内容---
            """;

        var myPromptConfig = new PromptTemplateConfig
        {
            Description = "对输入的内容进行简短总结.",
            Completion =
                        {
                            MaxTokens = 1000,
                            Temperature = 0.2,
                            TopP = 0.5,
                        }
        };

        var myPromptTemplate = new PromptTemplate(
            summarizeBlurbFlex,
            myPromptConfig,
            sk
        );

        var myFunctionConfig = new SemanticFunctionConfig(myPromptConfig, myPromptTemplate);

        var myFunction = sk.RegisterSemanticFunction(
            "TestSkillFlex",
            "summarizeBlurbFlex",
            myFunctionConfig);

        var myOutput = await sk.RunAsync(@"从“五一”的预订量看我们有95%左右的入住预订率，随着“五一”节临近，商务客比例在往下走，
                家庭出行、旅游观光的客人比例在上涨。还有个客群变化亮点是文艺活动增多，一有文艺节演出，
                这些文艺团队和观看观众在这边的入住率相对比例也在慢慢上升。
                除了市区酒店，也有不少消费者会选择位于上海市郊的特色民宿，希望在繁忙的日常节奏里找寻自然生活的轻松闲适。
                记者从上海市统计局了解到，今年一季度上海服务零售实现较快增长，1-3月，住宿和餐饮业实现零售额362.54亿元，增长14.3%。",
            myFunction);

        Console.WriteLine(myOutput);

    }

    static async Task Test2(IKernel sk)
    {
        string summarizeBlurbFlex = """
            请使用两句话总结以下内容. 
            ---开始内容---
            {{$INPUT}}
            ---结束内容---
            """;

        
        var mySummarizeFunction = sk.CreateSemanticFunction(summarizeBlurbFlex, maxTokens: 1000);

        var myOutput = await mySummarizeFunction.InvokeAsync(
            @"24日下午，人民大会堂，在巨幅壁画《江山如此多娇》前，习近平主席分别接受70位驻华大使递交国书，并同他们一一合影。
            面对各位使节，习近平主席指出，中方愿同国际社会一道，推进落实全球发展倡议、全球安全倡议、全球文明倡议，倡导全人类共同价值，促进各国人民相知相亲，共同应对各种全球性挑战，朝着构建人类命运共同体方向不断迈进。
            应邀对俄罗斯进行国事访问，同来华访问的亚洲、欧洲、拉美、非洲等多位政要会谈会见，首次提出全球文明倡议，推动国际和地区热点问题解决……2023年春季，高潮迭起的中国元首外交，持续吸引着世界的目光。在习近平主席引领下，中国特色大国外交在新征程上扬帆奋进，标注出中国与世界交往互动新高度。"
            );

        Console.WriteLine(myOutput);
    }
}
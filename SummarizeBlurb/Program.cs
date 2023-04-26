using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.KernelExtensions;
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
        sk.Config.AddOpenAITextCompletionService("OpenAI_davinci", "text-davinci-003", key!);

        /*
        var context = new ContextVariables();
        context.Set("input", @"从“五一”的预订量看我们有95%左右的入住预订率，随着“五一”节临近，商务客比例在往下走，
                家庭出行、旅游观光的客人比例在上涨。还有个客群变化亮点是文艺活动增多，一有文艺节演出，
                这些文艺团队和观看观众在这边的入住率相对比例也在慢慢上升。
                除了市区酒店，也有不少消费者会选择位于上海市郊的特色民宿，希望在繁忙的日常节奏里找寻自然生活的轻松闲适。
                记者从上海市统计局了解到，今年一季度上海服务零售实现较快增长，1-3月，住宿和餐饮业实现零售额362.54亿元，增长14.3%。");

        var skill = sk.ImportSemanticSkillFromDirectory("MySkills", "TestSkill");
        var skContext  = await sk.RunAsync(context, skill["Summarize"]);
        Console.WriteLine(skContext.Result);
        */

        string summarizeBlurbFlex = """
Summarize the following text in two sentences or less. 
---Begin Text---
{{$INPUT}}
---End Text---
""";

        var myPromptConfig = new PromptTemplateConfig
        {
            Description = "Take an input and summarize it super-succinctly.",
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

        var myOutput = await sk.RunAsync("This is my input that will get summarized for me. And when I go off on a tangent it will make it harder. But it will figure out that the only thing to summarize is that this is a text to be summarized. You think?",
            myFunction);

        Console.WriteLine(myOutput);
    }
}
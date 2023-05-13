
using Common;

using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Orchestration;

class Program
{
    public static async Task Main(string[] args)
    {
        var key = OpenAI.GetApiKey();

        var sk = Kernel.Builder.Build();
        sk.Config.AddOpenAITextCompletionService("text-davinci-003", key!,serviceId: "OpenAI_davinci");

        var skill = sk.ImportSemanticSkillFromDirectory("MySkillsDirectory", "TestSkill");
        var context = new ContextVariables();
        context.Set("input", "烧烤店");

        var result = await sk.RunAsync(context, skill["SloganMaker"]);
        await Console.Out.WriteLineAsync(result.Result);
    }
}


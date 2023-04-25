
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.KernelExtensions;
using Microsoft.SemanticKernel.Orchestration;

class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("please input your OpenAI key ...");
        var key = Console.ReadLine();

        var sk = Kernel.Builder.Build();
        sk.Config.AddOpenAITextCompletionService(
            "OpenAI_davinci", "text-davinci-003",
            key!);

        var skill = sk.ImportSemanticSkillFromDirectory("MySkillsDirectory", "TestSkill");
        var context = new ContextVariables();
        context.Set("input", "Basketweaving Service");

        var result = await sk.RunAsync(context, skill["SloganMaker"]);
        await Console.Out.WriteLineAsync(result.Result);
    }
}


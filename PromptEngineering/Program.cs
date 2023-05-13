namespace PromptEngineering;

internal class Program
{
    static async Task Main(string[] args)
    {
        var runner = new P01_提示分隔符();
        await runner.RunAsync();
    }
}
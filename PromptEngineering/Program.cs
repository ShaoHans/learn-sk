namespace PromptEngineering;

internal class Program
{
    static async Task Main(string[] args)
    {
        await TestOpenAIServiceAsync();
    }

    static Dictionary<int, IPromptRunner> GetRunnerInstances()
    {
        var runnerTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IPromptRunner))));

        var runners = new Dictionary<int, IPromptRunner>();
        foreach (var type in runnerTypes.OrderBy(t => t.Name))
        {
            var index = int.Parse(type.Name.Split('_')[0].Trim('P'));
            var runner = Activator.CreateInstance(type) as IPromptRunner;
            runners[index] = runner!;
        }
        return runners;
    }

    static async Task TestOpenAIServiceAsync()
    {
        while(true)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("****************************************************");
            Console.WriteLine("存在以下OpenAI案例：");
            var runners = GetRunnerInstances();

            foreach (var item in runners)
            {
                Console.WriteLine($"*** {item.Key}：{item.Value.GetType().Name}");
            }

            Console.WriteLine("请输入案例的索引号（输入不存在的索引号将退出程序）：");
            if(int.TryParse(Console.ReadLine()!,out int index))
            {
                if (runners.TryGetValue(index, out IPromptRunner runner))
                {
                    await runner.RunAsync();
                }
            }
            else
            {
                break;
            }
        }
    }
}
﻿namespace PromptEngineering;

internal class Program
{
    static async Task Main(string[] args)
    {
        IPromptRunner runner = null;
        Console.WriteLine("请输入案例索引号：");
        var index = Console.ReadLine();
        switch (index)
        {
            case "1":
                runner = new P01_提示分隔符();
                break;
            case "2":
                runner = new P02_结构化输出();
                break;
            case "3":
                runner = new P03_按步骤输出();
                break;
            case "4":
                runner = new P04_少样本提示();
                break;
            default:
                break;
        }

        if (runner != null)
        {
            await runner.RunAsync();
        }
        else
        {
            Console.WriteLine("无效的索引号");
        }
    }
}
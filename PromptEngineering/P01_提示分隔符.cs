using Common;

namespace PromptEngineering;

internal class P01_提示分隔符 : IPromptRunner
{
    /// <summary>
    /// 使用分隔符清晰的指出输入部分，
    /// 分隔符可以是：<tag></tag>,<>,```等符号
    /// </summary>
    /// <returns></returns>
    public async Task RunAsync()
    {
        var config = new OpenAIConfig
        {
            Template = """
                请使用两句话总结以下内容
                <div>{{$INPUT}}</div>
                """,
            Input = @"从上篇文章我们知道当多个CPU访问（此处访问的含义不仅有读取内存数据的意思，同时也有往内存写入数据的意思）同一个数据时，CPU存在着穿插执行的行为，从而造成数据紊乱的情况，为此CPU提供了锁机制来保证数据一致性，锁机制背后的原理就是通过CPU的一条原子性指令（原语）限制只能有一个CPU执行该指令。但我们的应用程序的某个方法往往是由多条指令（通过汇编器产生的ISA指令集）组成的，那一条原语指令如何保证多条指令的原子性呢？换个问法就是：应用程序的多个线程访问同一个方法时是如何保证线程安全的呢？"
        };

        var response = await OpenAI.GetTextCompletionAsync(config);
        OpenAI.Output(config, response);
    }
}

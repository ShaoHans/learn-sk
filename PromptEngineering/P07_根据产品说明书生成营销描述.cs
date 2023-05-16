using Common;

namespace PromptEngineering;

public class P07_根据产品说明书生成营销描述 : IPromptRunner
{
    public async Task RunAsync()
    {
        var config = new OpenAIConfig
        {
            Template = @"请根据【】括号中的产品说明书帮助营销团队生成简短的产品营销描述，描述内容最好是60个字符以内。
产品说明书：【{{$Input}}】",

            Input = @"产品名称：Xiaomi 13 Ultra

产品说明：徕卡光学全焦段四摄
一英寸可变光圈主摄｜75mm 徕卡专业长焦
120mm 徕卡专业超长焦｜122° 徕卡超低畸变广角
专业 2K 超色准屏
第二代骁龙®8移动平台｜动态性能调度 2.0
LPDDR5X 满血版 + UFS 4.0 + FBO 焕新存储
5000mAh 大电量｜小米澎湃电池管理系统
小米澎湃 P2 快充芯片｜小米澎湃 G1 电池管理芯片
Mi IceLoop 小米环形冷泵
90W 小米澎湃有线秒充
50W Pro 小米澎湃无线秒充｜反向充电
立体声双扬声器
康宁大猩猩玻璃 Victus
IP68级防尘防水

内存容量：16GB+1TB 最高可选
运行内存：12GB / 16GB LPDDR5X 高速内存（8533Mbps）
机身存储：256GB / 512GB / 1TB UFS 4.0 高速存储

外观尺寸
长度：163.18mm
宽度：74.64mm
厚度：9.06mm
重量：227g

移动平台
第二代骁龙®8移动平台
SoC 工艺：台积电 4nm 工艺制程
CPU 主频：八核处理器，最高主频可达：3.19GHz
GPU ：Adreno™ GPU 图形处理器
AI：高通 AI 引擎"

        };

        var response = await OpenAI.GetTextCompletionAsync(config);
        OpenAI.Output(config, response);
    }
}

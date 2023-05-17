using Common;

namespace PromptEngineering;

public class P07_根据产品说明书生成营销描述 : IPromptRunner
{
    public async Task RunAsync()
    {
        var config = new OpenAIConfig
        {
            Template = @"请根据【】括号中的产品说明书帮助营销团队生成简短的产品营销描述，
需要突出它的高配置以及性能表现，
描述内容最好是60个字符以内。
在描述内容的后面生成一个表格，表格的第一列是手机性能指标维度，第二列是维度对应的参数
产品说明书：【{{$Input}}】",

            Input = @"产品名称：Xiaomi 13 Ultra

产品说明：徕卡光学全焦段四摄
一英寸可变光圈主摄，75mm徕卡专业长焦，120mm徕卡专业超长焦，122°徕卡超低畸变广角，专业2K超色准屏。
第二代骁龙®8移动平台，动态性能调度2.0。
LPDDR5X 满血版 + UFS 4.0 + FBO 焕新存储。
5000mAh大电量，小米澎湃电池管理系统。
小米澎湃P2快充芯片，小米澎湃G1电池管理芯片。
Mi IceLoop 小米环形冷泵，90W小米澎湃有线秒充，50W Pro小米澎湃无线秒充，反向充电。
立体声双扬声器。
康宁大猩猩玻璃Victus，IP68级防尘防水。

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

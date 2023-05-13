using Microsoft.SemanticKernel.SemanticFunctions;

namespace Common;

public class OpenAIConfig
{
    public string EnvVariableName { get; set; } = "OPENAI_API_KEY";

    public string ModelId { get; set; } = "text-davinci-003";

    public string Input { get; set; }

    /// <summary>
    /// Prompt
    /// </summary>
    public string Template { get; set; }

    public PromptTemplateConfig PromptTemplateConfig { get; set; }= new PromptTemplateConfig
    {
        Description = "对输入的内容进行简短总结.",
        Completion = {
                        MaxTokens = 1000,
                        Temperature = 0.2,
                        TopP = 0.5,
                     }
    };

    public string SkillName { get; set; } = "TestSkill";

    public string FunctionName { get; set; } = "TestFunction";
}

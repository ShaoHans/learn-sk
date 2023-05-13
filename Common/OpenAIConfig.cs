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

    public PromptTemplateConfig PromptTemplateConfig { get; set; }

    public string SkillName { get; set; } = "TestSkill";

    public string FunctionName { get; set; } = "TestFunction";
}

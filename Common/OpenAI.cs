namespace Common;

public class OpenAI
{
    public static string GetApiKey(string envVariableName = "OPENAI_API_KEY")
    {
        var key = Environment.GetEnvironmentVariable(envVariableName);
        if(string.IsNullOrEmpty(key))
        {
            Console.WriteLine("please input your OpenAI Api Key ...");
            key = Console.ReadLine();
        }
        return key;
    }
}
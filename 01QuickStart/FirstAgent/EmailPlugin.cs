using Microsoft.SemanticKernel;

using System.ComponentModel;

namespace FirstAgent;

internal class EmailPlugin
{
    [KernelFunction("send_email")]
    [Description("Sends an email to a recipient.")]
    public async Task SendEmailAsync(string to, string subject, string body)
    {
        Console.WriteLine($"send to {to},the subject is :{subject} ,the body is :{body}");
    }
}

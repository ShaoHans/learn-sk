using LearnSk.Core;
using LearnSk.Core.Configurations;

using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;

namespace Microsoft.Extensions.DependencyInjection;

public static class KernelServiceExtensions
{
    public static IServiceCollection AddAzureOpenAI(this IServiceCollection services)
    {
        var configuration = services.GetConfiguration();
        var cfg = configuration.GetSection("AzureOpenAI").Get<AzureOpenAIConfiguration>();
        
        var kernelBuilder = services.AddKernel();
        kernelBuilder.Services.AddAzureOpenAITextGeneration(
            deploymentName: cfg.Deployment,
            endpoint: cfg.Endpoint,
            apiKey: cfg.ApiKey);
        kernelBuilder.Services.AddAzureOpenAIChatCompletion(
            deploymentName: cfg.Deployment,
            endpoint: cfg.Endpoint,
            apiKey: cfg.ApiKey);
        return services;
    }
}

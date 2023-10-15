using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace AzureProject.Implementations;

public static class DependencyInjections
{
    public static Assembly RegisterAzure(this IServiceCollection services)
    {
        return typeof(DependencyInjections).Assembly;
    }
}
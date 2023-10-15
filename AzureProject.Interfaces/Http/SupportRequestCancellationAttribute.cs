using AzureProject.Interfaces.Context;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace AzureProject.Interfaces.Http;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
public sealed class SupportRequestCancellationAttribute : Attribute, IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var executionContextProvider = context.HttpContext.RequestServices.GetRequiredService<IExecutionContextProvider>();
        executionContextProvider.CancellationToken = context.HttpContext.RequestAborted;
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}
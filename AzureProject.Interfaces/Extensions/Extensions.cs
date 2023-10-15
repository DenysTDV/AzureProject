using AzureProject.Interfaces.Context;
using AzureProject.Interfaces.Handlers.Responses;

namespace AzureProject.Interfaces.Extensions;

public static class Extensions
{
    public static async Task<T> HandleAsyncRequest<T>(this IRequestProvider target, Func<CancellationToken, Task<T>> requestProcessing, CancellationToken cancellationToken)
        where T : IResponse, new()
    {
        try
        {
            var response = await requestProcessing(cancellationToken);
            return response;
        }
        catch (Exception ex)
        {
            return HandleError<T>(ex);
        }
    }

    private static T HandleError<T>(Exception ex)
        where T : IResponse, new()
    {
        var response = new T();
        response.ResponseMessage = ex.Message;

        return response;
    }
}
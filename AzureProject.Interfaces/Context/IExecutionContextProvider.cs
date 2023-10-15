using Microsoft.AspNetCore.Http;

namespace AzureProject.Interfaces.Context;

public interface IExecutionContextProvider
{
    string Url { get; set; }

    CancellationToken CancellationToken { get; set; }

    public IHeaderDictionary Headers { get; set; }
}
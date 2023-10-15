using AzureProject.Interfaces.Handlers.Requests;
using AzureProject.Interfaces.Handlers.Responses;

namespace AzureProject.Interfaces;

public interface IYelpApi
{
    Task<SearchApiResponse> Search(SearchApiRequest request);
}
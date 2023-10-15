using AutoMapper;
using AzureProject.Interfaces.Handlers.Requests;
using AzureProject.Interfaces.Handlers.Responses;

namespace AzureProject.Implementations;

public class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        this.CreateMap<SearchApiRequest, SearchRequest>();
        this.CreateMap<SearchResponse, SearchApiResponse>();
    }
}
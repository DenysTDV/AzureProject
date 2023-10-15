using AutoMapper;
using AzureProject.Interfaces.Handlers.Requests;
using AzureProject.Interfaces.Handlers.Responses;
using MediatR;

namespace AzureProject.Implementations.Handlers;

public class SearchHandler : IRequestHandler<SearchRequest, SearchResponse>
{
    public SearchHandler(IMapper mapper)
    {
        this.Mapper = mapper;
    }

    public IMapper Mapper { get; }

    // to do: implement logic
    public async Task<SearchResponse> Handle(SearchRequest request, CancellationToken cancellationToken)
    {
        return new SearchResponse();
    }
}
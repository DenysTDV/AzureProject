using AutoMapper;
using AzureProject.Interfaces;
using AzureProject.Interfaces.Context;
using AzureProject.Interfaces.Handlers.Requests;
using AzureProject.Interfaces.Handlers.Responses;
using AzureProject.Interfaces.Http;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AzureProject.Controllers;

[ApiController]
[SupportRequestCancellation]
public class YelpController : BaseApiController, IYelpApi
{
    public YelpController(
        IMediator mediator, IMapper mapper, IExecutionContextProvider executionContextProvider)
        : base(mediator, mapper, executionContextProvider)
    {
    }

    [HttpPost(nameof(Search))]
    public Task<SearchApiResponse> Search(SearchApiRequest request) =>
        this.Handle<SearchApiRequest, SearchRequest, SearchApiResponse>(request);
}
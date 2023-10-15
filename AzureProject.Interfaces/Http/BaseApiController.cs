using AutoMapper;
using AzureProject.Interfaces.Context;
using AzureProject.Interfaces.Extensions;
using AzureProject.Interfaces.Handlers.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AzureProject.Interfaces.Http;

[Route("api/[controller]")]
[Produces("application/json")]
public class BaseApiController : ControllerBase, IRequestProvider
{
    protected BaseApiController(
        IMediator mediator,
        IMapper mapper,
        IExecutionContextProvider executionContextProvider)
    {
        this.Mediator = mediator;
        this.Mapper = mapper;
        this.ExecutionContextProvider = executionContextProvider;
    }


    public IMapper Mapper { get; set; }

    public IMediator Mediator { get; set; }

    public IExecutionContextProvider ExecutionContextProvider { get; set; }

    protected virtual Task<TResponse> Handle<TApiRequest, TRequest, TResponse>(TApiRequest request)
        where TResponse : IResponse, new()
    {
        return this.HandleAsyncRequest(
            async cancellationToken =>
            {
                var response = await this.Mediator.Send(this.DecorateRequest(this.Mapper.Map<TRequest>(request)), cancellationToken);
                var apiResponse = this.Mapper.Map<TResponse>(response);

                var decoratedResponse = this.DecorateResponse(apiResponse, response);

                return decoratedResponse;
            },
            this.ExecutionContextProvider.CancellationToken);
    }

    protected virtual TRequest DecorateRequest<TRequest>(TRequest request) => request;

    protected virtual TApiResponse DecorateResponse<TApiResponse, TResponse>(TApiResponse apiResponse, TResponse response) => apiResponse;
}
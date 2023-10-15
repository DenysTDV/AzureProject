using System.Runtime.Serialization;
using AzureProject.Interfaces.Handlers.Responses;
using MediatR;

namespace AzureProject.Interfaces.Handlers.Requests;

[DataContract]
public class SearchRequest : IRequest<SearchResponse>
{

}
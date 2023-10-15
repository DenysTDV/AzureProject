using System.Runtime.Serialization;

namespace AzureProject.Interfaces.Handlers.Responses;

[DataContract]
public class BaseApiResponse : IResponse
{
    public string ResponseMessage { get; set; }
}
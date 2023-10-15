namespace AzureProject.Interfaces.Context;

public interface IRequestProvider
{
    IExecutionContextProvider ExecutionContextProvider { get; }
}
namespace SmartRep_Backend.Application.Exceptions;
internal class ExecutionFailedExeption : Exception
{
    public ExecutionFailedExeption(string message) : base(message) { }
}

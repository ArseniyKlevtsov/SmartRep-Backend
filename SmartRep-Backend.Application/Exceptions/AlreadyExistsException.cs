namespace SmartRep_Backend.Application.Exceptions;
public class AlreadyExistsException : Exception
{
    public AlreadyExistsException(string message) : base(message) { }
}
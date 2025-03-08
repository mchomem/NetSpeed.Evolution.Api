namespace NetSpeed.Evolution.Core.Domain.Exceptions.JobTitle;

public class JobTitleAlreadyExistsException : JobTitleException
{
    public JobTitleAlreadyExistsException(string message = DefaultMessages.JobTitleAlreadyExists) : base(message) { }
}

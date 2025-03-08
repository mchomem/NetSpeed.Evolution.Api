namespace NetSpeed.Evolution.Core.Domain.Exceptions.JobTitle;

public class JobTitleNotFoundException : JobTitleException
{
    public JobTitleNotFoundException(string message = DefaultMessages.JobTitleNotFound) : base(message) { }
}

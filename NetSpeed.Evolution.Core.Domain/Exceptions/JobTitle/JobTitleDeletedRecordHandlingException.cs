namespace NetSpeed.Evolution.Core.Domain.Exceptions.JobTitle;

public class JobTitleDeletedRecordHandlingException : JobTitleException
{
    public JobTitleDeletedRecordHandlingException(string message = DefaultMessages.JobTitleDeletedRecordHandling) : base(message) { }
}

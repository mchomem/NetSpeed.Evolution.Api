namespace NetSpeed.Evolution.Core.Domain.Exceptions.Department;

public class DepartmentDeletedRecordHandlingException : DepartmentException
{
    public DepartmentDeletedRecordHandlingException(string message = DefaultMessages.DepartmentDeletedRecordHandling) : base(message) { }
}

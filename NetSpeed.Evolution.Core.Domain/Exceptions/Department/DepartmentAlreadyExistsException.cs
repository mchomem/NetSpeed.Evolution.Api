namespace NetSpeed.Evolution.Core.Domain.Exceptions.Department;

public class DepartmentAlreadyExistsException : DepartmentException
{
    public DepartmentAlreadyExistsException(string message = DefaultMessages.DepartmentAlreadyExists) : base(message) { }
}

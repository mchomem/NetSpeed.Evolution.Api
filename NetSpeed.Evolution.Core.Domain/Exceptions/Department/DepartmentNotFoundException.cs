namespace NetSpeed.Evolution.Core.Domain.Exceptions.Department;

public class DepartmentNotFoundException : DepartmentException
{
    public DepartmentNotFoundException(string message = DefaultMessages.DepartmentNotFound) : base(message) { }
}

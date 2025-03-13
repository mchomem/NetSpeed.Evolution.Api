namespace NetSpeed.Evolution.Core.Domain.Exceptions.Employee;

public class EmployeeAlreadyExistsException : EmployeeException
{
    public EmployeeAlreadyExistsException(string message = DefaultMessages.EmployeeAlreadyExists) : base(message) { }
}

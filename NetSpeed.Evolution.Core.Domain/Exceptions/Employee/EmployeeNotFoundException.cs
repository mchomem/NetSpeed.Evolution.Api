namespace NetSpeed.Evolution.Core.Domain.Exceptions.Employee;

public class EmployeeNotFoundException : EmployeeException
{
    public EmployeeNotFoundException(string message = DefaultMessages.EmployeeNotFound) : base(message) { }
}

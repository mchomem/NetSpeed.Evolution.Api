namespace NetSpeed.Evolution.Tests;

public class UserUnitTest
{
    /* Melhores práticas para nomes de métodos de testes unitários:
     
        O nome do seu teste deve ser composto por três partes:

        O nome do método que está sendo testado.
        O cenário em que ele está sendo testado.
        O comportamento esperado quando o cenário é invocado.

        Fonte: https://learn.microsoft.com/pt-br/dotnet/core/testing/unit-testing-best-practices
     */

    [Fact]
    public void CheckPassword_SingleString_ReturnUserPasswordInsufficientLengthException()
    {
        // Arrange
        var user = new User("john.thunder", "john12345");

        // Act & Assert
        Assert.Throws<UserPasswordInsufficientLengthException>(() =>
        {
            user.CheckPassword("123");
        });
    }

    [Fact]
    public void CheckPassword_SingleString_ReturnUserPasswordWithoutLettersException()
    {
        // Arrange
        var user = new User("john.thunder", "john12345");

        // Act & Assert
        Assert.Throws<UserPasswordWithoutLettersException>(() =>
        {
            user.CheckPassword("0123456789");
        });
    }

    [Fact]
    public void CheckPassword_SingleString_ReturnUserPasswordWithoutNumbersException()
    {
        // Arrange
        var user = new User("john.thunder", "john12345");

        // Act & Assert
        Assert.Throws<UserPasswordWithoutNumbersException>(() =>
        {
            user.CheckPassword("john.thunder");
        });
    }
}

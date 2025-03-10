namespace NetSpeed.Evolution.Tests;

public class UserUnitTest
{
    /* Melhores pr�ticas para nomes de m�todos de testes unit�rios:
     
        O nome do seu teste deve ser composto por tr�s partes:

        O nome do m�todo que est� sendo testado.
        O cen�rio em que ele est� sendo testado.
        O comportamento esperado quando o cen�rio � invocado.

        Fonte: https://learn.microsoft.com/pt-br/dotnet/core/testing/unit-testing-best-practices
     */

    [Fact]
    public void ChangePassword_SingleString_ReturnUserPasswordInsufficientLengthException()
    {
        // Arrange
        var user = new User("john.thunder", "john12345");

        // Act & Assert
        Assert.Throws<UserPasswordInsufficientLengthException>(() =>
        {
            user.ChangePassword("123");
        });
    }

    [Fact]
    public void ChangePassword_SingleString_ReturnUserPasswordWithoutLettersException()
    {
        // Arrange
        var user = new User("john.thunder", "john12345");

        // Act & Assert
        Assert.Throws<UserPasswordWithoutLettersException>(() =>
        {
            user.ChangePassword("0123456789");
        });
    }

    [Fact]
    public void ChangePassword_SingleString_ReturnUserPasswordWithoutNumbersException()
    {
        // Arrange
        var user = new User("john.thunder", "john12345");

        // Act & Assert
        Assert.Throws<UserPasswordWithoutNumbersException>(() =>
        {
            user.ChangePassword("john.thunder");
        });
    }
}

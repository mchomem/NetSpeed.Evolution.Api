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

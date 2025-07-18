namespace NetSpeed.Evolution.Core.Application.Interfaces;

public interface ICypherService
{
    public string Decrypt(string value);
    public string Encrypt(string value);
}

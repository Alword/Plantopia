namespace Plantopia.WebApi2.Data.Interfaces
{
    public interface IPasswordSalter
    {
        byte[] SaltPassword(string password);

        bool EqualsSequence(string password, byte[] saltedKey);
    }
}

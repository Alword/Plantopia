namespace Plantopia.WebApi.Interfaces
{
    public interface IPasswordSalter
    {
        byte[] SaltPassword(string password);

        bool EqualsSequence(string password, byte[] saltedKey);
    }
}

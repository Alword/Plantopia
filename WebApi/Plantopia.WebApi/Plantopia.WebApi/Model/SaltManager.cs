using System.Linq;
using System.Security.Cryptography;
using Plantopia.WebApi.Interfaces;

namespace Plantopia.WebApi.Model
{
    /// <summary>
    /// </summary>
    // ReSharper disable once HollowTypeName
    public class SaltManager : IPasswordSalter
    {
        private const int MYSQL_BUFFER = 128;
        private const int SALT_BUFFER = 32;
        private const int KEY_BUFFER = MYSQL_BUFFER - SALT_BUFFER;

        /// <summary>
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public byte[] SaltPassword(string password)
        {
            byte[] salt, key;

            // specify that we want to randomly generate a 32-byte salt
            using (var deriveBytes = new Rfc2898DeriveBytes(password, SALT_BUFFER))
            {
                salt = deriveBytes.Salt;
                key = deriveBytes.GetBytes(KEY_BUFFER); // derive a 96-byte key
            }

            byte[] saltedKey = salt.Concat(key).ToArray();
            ;

            return saltedKey;
        }

        /// <summary>
        /// </summary>
        /// <param name="password"></param>
        /// <param name="saltedKey"></param>
        /// <returns></returns>
        public bool EqualsSequence(string password, byte[] saltedKey)
        {
            byte[] key = saltedKey.Skip(SALT_BUFFER).ToArray();
            byte[] salt = saltedKey.Take(SALT_BUFFER).ToArray();

            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt))
            {
                byte[] newKey = deriveBytes.GetBytes(KEY_BUFFER); // derive a 96-byte key

                return newKey.SequenceEqual(key);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plantopia.WebApi.Data.Interfaces
{
    public interface IPasswordSalter
    {
        byte[] SaltPassword(string password);

        bool EqualsSequence(string password, byte[] saltedKey);
    }
}

using Plantopia.Service.Auth.Interfaces;
using Plantopia.Service.Auth.Models;

namespace Plantopia.Service.Auth
{
    public static class AuthOptions
    {
        public const string ISSUER = "InWords.Auth"; // token publisher
        public const string AUDIENCE = "http://localhost:80/"; // the consumer token http://localhost:5000/
        public const int LIFETIME = 60; // the token lifetime, in minutes

        public static readonly IJwtProvider TokenProvider;

        static AuthOptions()
        {
            TokenProvider = new SymmetricJwtTokenProvider(
                ISSUER,
                AUDIENCE,
                LIFETIME);
        }
    }
}

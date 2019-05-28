using System.Security.Claims;
using Plantopia.Service.Auth.Extensions;

namespace Plantopia.Service.Auth.Models
{
    public class TokenResponse
    {
        public TokenResponse(ClaimsIdentity identity)
        {
            // receive token
            string encodedJwt = AuthOptions.TokenProvider.GenerateToken(identity);
            Token = Cheeked(encodedJwt, out string errMsg);
            UserId = identity.Claims.GetUserId();

        }

        private static string Cheeked(string encodedJwt, out string errorMsg)
        {
            errorMsg = "";
            if (encodedJwt == null) errorMsg = "Token fail";
            return encodedJwt;
        }

        public string Token { get; }

        public int UserId { get; }
    }
}

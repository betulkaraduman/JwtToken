using Microsoft.IdentityModel.Tokens;

namespace JwtApp_141022.TokenGenerator
{
    public class JwtTokenSettings
    {
        public const string Issuer = "http://localhost";
        public const string Audience = "http://localhost";
        public const string Key = "BetulKaraduman01.";
        public const int Expire = 30;

    }
}

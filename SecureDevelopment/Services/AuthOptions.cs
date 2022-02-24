using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace SecureDevelopment.Services
{
    public static class AuthOptions
    {
        public const string Issuer = "VeryCoolServer"; // издатель токена
        public const string Audience = "ClientsOfServer"; // потребитель токена
        private const string Key = "0I8&m9D%6s(OLQ(7";   // ключ для шифрации
        public const int LifeTime = 86400; // время жизни токена

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}
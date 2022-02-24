using SecureDevelopment.Model;

namespace SecureDevelopment.Services
{
    public interface IAuthorization
    {
        public string GetTokenKey(UserAccount user);
    }
}
using SecureDevelopment.Model;

namespace SecureDevelopment.Repository
{
    public interface IRepositoryUser
    {
        public int Add(UserAccount user);
        public UserAccount GetUser(UserAccount user);
        public int GetIdUserByName(string userName);
        public int Update(UserAccount user);
        public int Delete(int userId);
    }
}
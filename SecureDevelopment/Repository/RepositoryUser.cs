#nullable enable
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using SecureDevelopment.Model;
using SecureDevelopment.Services;

namespace SecureDevelopment.Repository
{
    public class RepositoryUser : IRepositoryUser
    {
        public int Add(UserAccount user)
        {
            int result = -1;
            string passwordHash = Crypto.GetHash(user.Password);
            using (var connection = new MySqlConnection(Connect.GetConnectionString()))
            {
                result = connection.Execute("INSERT INTO users (Login, PasswordHash, Role) " + 
                                            "VALUES (@login, @passwordHash, @role);", 
                    new
                    {
                        login = user.Login,
                        passwordHash = passwordHash,
                        role = user.Role
                    });
            }

            return result;
        }

        public UserAccount GetUser(UserAccount user)
        {
            UserAccount result;
            using (var connection = new MySqlConnection(Connect.GetConnectionString()))
            {
                result = connection.QueryFirstOrDefault<UserAccount>(
                    "SELECT id, login, role FROM users WHERE Login = @login AND PasswordHash = @passwordHash", new
                    {
                        login = user.Login,
                        passwordHash = Crypto.GetHash(user.Password)
                    });
            }

            return result;
        }
        public int GetIdUserByName(string userName)
        {
            var result = -1;
            using (var connection = new MySqlConnection(Connect.GetConnectionString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("login",userName);
                
                result = connection.QueryFirstOrDefault<int>(
                    "SELECT Id FROM users WHERE Login = @login", parameters);
            }

            return result;
        }
        public int Update(UserAccount user)
        {
            int result = -1;
            using (var connection = new MySqlConnection(Connect.GetConnectionString()))
            {
                result = connection.Execute("UPDATE users SET Login=@login, PasswordHash=@passwordHash, " +
                                            "Role=@role WHERE Id=@id",
                    new
                    {
                        login = user.Login,
                        passwordHash = Crypto.GetHash(user.Password),
                        role = user.Role,
                        id = user.Id
                    });
            }

            return result;
        }

        public int Delete(int userId)
        {
            int result = -1;
            using (var connection = new MySqlConnection(Connect.GetConnectionString()))
            {
                result = connection.Execute("DELETE FROM users WHERE Id = @id", new
                {
                    id = userId
                });
            }

            return result;
        }
    }
}
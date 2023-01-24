namespace SecureDevelopment.Model
{
    internal enum UserRoles
    {
        Administrator,
        User
    }
    public class UserAccount
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
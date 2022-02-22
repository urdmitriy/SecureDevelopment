namespace SecureDevelopment
{
    public static class Connect
    {
        private const string ConnectionString = "server=localhost;port=3306;user=dmitriy;database=gb;password=j0pA212142123";

        public static string GetConnectionString()
        {
            return ConnectionString;
        }
    }
}
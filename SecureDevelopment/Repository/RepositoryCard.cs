using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace SecureDevelopment.Repository
{
    public class RepositoryCard : IRepositoryCard
    {
        public int Create(DebitCard newCard)
        {
            var result = -1;

            using var connection = new MySqlConnection(Connect.GetConnectionString());
            
            connection.Open();

            using var command = new MySqlCommand(
                       $"INSERT INTO debitcards (CardHolderName, CardNumber, DateOfUse) "+
                       $"VALUES ('{newCard.CardHolderName}', '{newCard.CardNumber}', '{newCard.DateOfUse.ToString("d")}')",
                       connection);
            
            result = command.ExecuteNonQuery();

            connection.Close();

            return result;
        }

        public DebitCard Read(int idCard)
        {
            var result = new DebitCard();
            using var connection = new MySqlConnection(Connect.GetConnectionString());
            connection.Open();
            using var command = new MySqlCommand($"SELECT * FROM debitcards WHERE Id={idCard}", connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result = new DebitCard()
                    {
                        Id = reader.GetInt32(0),
                        CardHolderName = reader.GetString(1),
                        CardNumber = reader.GetString(2),
                        DateOfUse = reader.GetDateTime(3)
                    };
                }
            }

            return result;
        }

        public IList<DebitCard> Read()
        {
            using var connection = new MySqlConnection(Connect.GetConnectionString());
            connection.Open();
            using var command = new MySqlCommand($"SELECT * FROM debitcards", connection);

            var returnList = new List<DebitCard>();

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    returnList.Add(new DebitCard()
                    {
                        Id = reader.GetInt32(0),
                        CardHolderName = reader.GetString(1),
                        CardNumber = reader.GetString(2),
                        DateOfUse = reader.GetDateTime(3)
                    });
                }
            }
            connection.Close();

            return returnList;
        }

        public int Update(DebitCard newCard)
        {
            int result = -1;
            using var connection = new MySqlConnection(Connect.GetConnectionString());
            connection.Open();
            using var command = new MySqlCommand(
                $"UPDATE debitcards SET CardHolderName = '{newCard.CardHolderName}', CardNumber = '{newCard.CardNumber}', " + 
                                                 $"DateOfUse = '{newCard.DateOfUse.ToString("d")}' where Id = {newCard.Id}", connection);
            result = command.ExecuteNonQuery();
            return result;
        }

        public int Delete(int newCardId)
        {
            int result = -1;
            using var connection = new MySqlConnection(Connect.GetConnectionString());
            connection.Open();
            using var command = new MySqlCommand($"DELETE FROM debitcards where Id = {newCardId}", connection);
            result = command.ExecuteNonQuery();
            return result;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;

namespace SecureDevelopment.Repository
{
    public class RepositoryCardDapper : IRepositoryCardDapper
    {
        public int Create(DebitCard newCard)
        {
            var result = -1;
            using (var connection = new MySqlConnection(Connect.GetConnectionString()))
            {
                result = connection.Execute("INSERT INTO debitcards (CardHolderName, CardNumber, DateOfUse) "+
                                            "VALUES (@name, @number, @date)", new
                {
                    name = newCard.CardHolderName,
                    number = newCard.CardNumber,
                    date = newCard.DateOfUse
                });
            }

            return result;
        }

        public DebitCard Read(int idCard)
        {
            DebitCard result;
            using (var connection = new MySqlConnection(Connect.GetConnectionString()))
            {
                result = connection.QueryFirstOrDefault<DebitCard>("SELECT * FROM debitcards WHERE Id=@id", new
                {
                    id = idCard
                });
            }

            return result==null?new DebitCard():result;
        }

        public IList<DebitCard> Read()
        {
            IList<DebitCard> result;
            using (var connection = new MySqlConnection(Connect.GetConnectionString()))
            {
                result = connection.Query<DebitCard>("SELECT * FROM debitcards").ToList();
            }
            
            return result;
        }

        public int Update(DebitCard newCard)
        {
            int result = -1;
            using (var connection = new MySqlConnection(Connect.GetConnectionString()))
            {
                result = connection.Execute("UPDATE debitcards SET CardHolderName = @name, CardNumber = @number, " + 
                                            "DateOfUse = @date where Id = @id", new
                {
                    name = newCard.CardHolderName,
                    number = newCard.CardNumber,
                    date = newCard.DateOfUse,
                    id = newCard.Id
                });
            }

            return result;
        }

        public int Delete(int newCardId)
        {
            int result = -1;
            using (var connection = new MySqlConnection(Connect.GetConnectionString()))
            {
                result = connection.Execute("DELETE FROM debitcards where Id = @id", new
                {
                    id = newCardId
                });
            }

            return result;
        }
    }
}
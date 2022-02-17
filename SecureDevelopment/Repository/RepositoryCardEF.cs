using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SecureDevelopment.Repository
{
    public class RepositoryCardEf : IRepositoryCardEf
    {
        public int Create(DebitCard newCard)
        {
            int result;
            using (var db = new ApplicationContext())
            {
                db.DebitCards.Add(newCard);
                result = db.SaveChanges();
            }

            return result;
        }

        public DebitCard Read(int idCard)
        {
            DebitCard result;
            using (var db = new ApplicationContext())
            {
                result = db.DebitCards.Find(idCard);
            }

            return result;
        }

        public IList<DebitCard> Read()
        {
            List<DebitCard> result;
            using (var db = new ApplicationContext())
            {
                result = db.DebitCards.ToList();
            }

            return result;
        }

        public int Update(DebitCard newCard)
        {
            int result = -1;
            using (var db = new ApplicationContext())
            {
                var currentCard = db.DebitCards.Find(newCard.Id);
                currentCard.CardNumber = newCard.CardNumber;
                currentCard.CardHolderName = newCard.CardHolderName;
                currentCard.DateOfUse = newCard.DateOfUse;
                result = db.SaveChanges();
            }

            return result;
        }

        public int Delete(int deleteCardId)
        {
            int result = -1;
            using (var db = new ApplicationContext())
            {
                var deleteCard = db.DebitCards.Find(deleteCardId);
                if (deleteCard != null)
                {
                    db.DebitCards.Remove(deleteCard);
                    result = db.SaveChanges();
                }
            }

            return result;
        }
    }
}
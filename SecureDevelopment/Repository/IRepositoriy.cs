using System.Collections.Generic;

namespace SecureDevelopment.Repository
{
    public interface IRepositoriy
    {
        public int Create(DebitCard newCard);
        public DebitCard Read(int idCard);
        public IList<DebitCard> Read();
        public int Update(DebitCard newCard);
        public int Delete(int newCardId);
    }
}
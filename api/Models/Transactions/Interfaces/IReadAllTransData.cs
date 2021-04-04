using System.Collections.Generic;

namespace api.Models.Transactions.Interfaces
{
    public interface IReadAllTransData
    {
        public List<Transaction> ReadAllTrans();
    }
}
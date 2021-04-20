using System.Collections.Generic;

namespace API.Models.Transactions.Interfaces
{
    public interface IReadAllTransData
    {
        public List<Transaction> ReadAllTrans();
    }
}
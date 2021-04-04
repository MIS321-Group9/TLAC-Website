using System.Transactions;
using System.Collections.Generic;
using api.Models.Transactions.Interfaces;

namespace api.Models.Transactions
{
    public class ReadTransData : IReadAllTransData, IReadTrans
    {
        public List<Transaction> ReadAllTrans()
        {

        }

        public Transaction ReadTrans(int Id)
        {
            
        }
    }
}
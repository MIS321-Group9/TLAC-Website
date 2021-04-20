namespace API.Models.Transactions.Interfaces
{
    public interface IReadTrans
    {
        public Transaction ReadTrans(int TransactionID);
    }
}
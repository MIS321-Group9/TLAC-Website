namespace API.Models.Transactions.Interfaces
{
    public interface IModifyTrans
    {
        public void SaveTrans(Transaction trans, int TransactionID);
    }
}
using System;
using api.Models.Transactions.Interfaces;

namespace api.Models.Transactions
{
    public class Transaction
    {
        public int Id {get; set;}
        public bool IsRefunded {get; set;}
        public DateTime TransactionDate {get; set;}
        public double Price {get; set;}
        public double CurrentBalance {get; set;}
        public int SessionID {get; set;}
        public int DiscountID {get; set;}
        public int CreditCardID {get; set;}
        public IModifyTrans Save {get; set;}
        public ICreateTrans Create {get; set;}
        public IDeleteTrans Delete {get; set;}

        public Transaction()
        {
            Save = new ModifyTrans();
            Delete = new DeleteTrans();
            Create = new CreateTrans();
        }
    }
}
using System;
using api.Models.Transactions.Interfaces;
using MySql.Data.MySqlClient;

namespace api.Models.Transactions
{
    public class ModifyTrans : IModifyTrans
    {
        public void SaveTrans(Transaction trans, int TransactionID)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $@"UPDATE ttransactions SET isRefunded=@isRefunded, transactiondate=@transactiondate, currentbalance=@currentbalance, price=@price, sessionid=@sessionid, discountid=@discountid, cardid=@cardid, customerid=@customerid, trainerid=@trainerid WHERE transactionid={TransactionID}";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@isrefunded", trans.IsRefunded);
            cmd.Parameters.AddWithValue("@transactiondate", DateTime.Now);
            cmd.Parameters.AddWithValue("@currentbalance", trans.CurrentBalance);
            cmd.Parameters.AddWithValue("@price", trans.Price);
            cmd.Parameters.AddWithValue("@sessionid", trans.SessionID);
            cmd.Parameters.AddWithValue("@discountid", trans.DiscountID);
            cmd.Parameters.AddWithValue("@cardid", trans.CardID);
            cmd.Parameters.AddWithValue("@customerid", trans.CustomerID);
            cmd.Parameters.AddWithValue("@trainerid", trans.TrainerID);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}
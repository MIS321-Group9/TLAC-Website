using System.Transactions;
using System.Collections.Generic;
using api.Models.Transactions.Interfaces;
using MySql.Data.MySqlClient;

namespace api.Models.Transactions
{
    public class ReadTransData : IReadAllTransData, IReadTrans
    {
        public List<Transaction> ReadAllTrans()
        {
             List<Transaction> allTransactions = new List<Transaction>();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM transactions ORDER BY TransactionDate DESC";
            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                allTransactions.Add(new Transaction(){});
            }

            return allTransactions;
        }

        public Transaction ReadTrans(int TransactionID)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM transactions WHERE transactionId = @id";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id",TransactionID);
            cmd.Prepare();

            using MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();

            return new Transaction(){};
        }
    }
}
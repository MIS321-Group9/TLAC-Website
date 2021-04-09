using System.Transactions;
using System.Collections.Generic;
using api.Models.Transactions.Interfaces;

namespace api.Models.Transactions
{
    public class ReadTransData : IReadAllTransData, IReadTrans
    {
        public List<Transaction> ReadAllTrans()
        {
             List<Transaction> allTransaction = new List<Transaction>();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM sessions ORDER BY DateOfSession DESC";
            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                allTransaction.Add(new Transaction(){});
            }

            return allTransactions;
        }

        public Transaction ReadTrans(int Id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM sessions WHERE sessionId = @id";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id",Id);
            cmd.Prepare();

            using MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();

            return new Transaction(){};
        }
    }
}
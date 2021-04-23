using System.Transactions;
using System.Collections.Generic;
using API.Models.Transactions.Interfaces;
using MySql.Data.MySqlClient;

namespace API.Models.Transactions
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

            string stm = "SELECT * FROM ttransactions ORDER BY TransactionDate DESC";
            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                int disId;
                int cardId;
                int custId;
                int trainerId;
                try{
                    disId = rdr.GetInt32(6);
                }
                catch{
                    disId = 0;
                }
                try{
                    cardId = rdr.GetInt32(7);
                }
                catch{
                    cardId = 0;
                }
                try{
                    custId = rdr.GetInt32(8);
                }
                catch{
                    custId = 0;
                }
                try{
                    trainerId = rdr.GetInt32(9);
                }
                catch{
                    trainerId = 0;
                }
                allTransactions.Add(new Transaction(){
                    TransactionID=rdr.GetInt32(0),
                    IsRefunded=rdr.GetBoolean(1),
                    TransactionDate=rdr.GetDateTime(2),
                    CurrentBalance=rdr.GetDouble(3),
                    Price=rdr.GetDouble(4),
                    SessionID=rdr.GetInt32(5),
                    DiscountID=disId,
                    CardID=cardId,
                    CustomerID=custId,
                    TrainerID=trainerId,

                });
            }

            return allTransactions;
        }

        public Transaction ReadTrans(int TransactionID)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM ttransactions WHERE transactionid = @id";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id",TransactionID);
            cmd.Prepare();

            using MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
            
            int disId;
            int cardId;
            int custId;
            int trainerId;
            try{
                disId = rdr.GetInt32(6);
            }
            catch{
                disId = 0;
            }
            try{
                cardId = rdr.GetInt32(7);
            }
            catch{
                cardId = 0;
            }
            try{
                custId = rdr.GetInt32(8);
            }
            catch{
                custId = 0;
            }
            try{
                trainerId = rdr.GetInt32(9);
            }
            catch{
                trainerId = 0;
            }

            return new Transaction(){
                TransactionID=rdr.GetInt32(0),
                IsRefunded=rdr.GetBoolean(1),
                TransactionDate=rdr.GetDateTime(2),
                CurrentBalance=rdr.GetDouble(3),
                Price=rdr.GetDouble(4),
                SessionID=rdr.GetInt32(5),
                DiscountID=disId,
                CardID=cardId,
                CustomerID=custId,
                TrainerID=trainerId,
            };
        }
    }
}
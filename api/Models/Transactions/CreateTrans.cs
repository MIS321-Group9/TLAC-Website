using System;
using API.Models.Transactions.Interfaces;
using MySql.Data.MySqlClient;

namespace API.Models.Transactions
{
    public class CreateTrans : ICreateTrans
    {
        public static void CreateTransTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE tTRANSACTIONS(TransactionID INT AUTO_INCREMENT NOT NULL,IsRefunded BOOLEAN NOT NULL,TransactionDate DATETIME NOT NULL,CurrentBalance DOUBLE NOT NULL,Price DOUBLE NOT NULL,SessionID INT NOT NULL,DiscountID INT,CardID INT,CustomerID INT,TrainerID INT,PRIMARY KEY (TransactionID),FOREIGN KEY (SessionID) REFERENCES tSESSIONS(SessionID),FOREIGN KEY (DiscountID) REFERENCES tDISCOUNTS(DiscountID),FOREIGN KEY (CardID) REFERENCES tCREDITCARDS(CardID),FOREIGN KEY (CustomerID) REFERENCES tCUSTOMERS(CustomerID),FOREIGN KEY (TrainerID) REFERENCES tTRAINERS(TrainerID));";


            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }

        void ICreateTrans.CreateTrans(Transaction trans)
        {
            if (trans.CustomerID == 0)
            {
                ConnectionString myConnection = new ConnectionString();
                string cs = myConnection.cs;

                using var con = new MySqlConnection(cs);
                con.Open();
                string stm = @"INSERT INTO ttransactions(isrefunded, transactiondate, currentbalance, price, sessionid, trainerid) VALUES(@isrefunded, @transactiondate, @currentbalance, @price, @sessionid, @trainerid)";;

                
                //string stm = @"INSERT INTO ttransactions(isrefunded, transactiondate, currentbalance, price, sessionid, discountid, cardid, customerid, trainerid) VALUES(@isrefunded, @transactiondate, @currentbalance, @price, @sessionid, @discountid, @cardid, @customerid, @trainerid)";

                using var cmd = new MySqlCommand(stm, con);
                cmd.Parameters.AddWithValue("@isrefunded", false);
                cmd.Parameters.AddWithValue("@transactiondate", DateTime.Now);
                cmd.Parameters.AddWithValue("@currentbalance", trans.CurrentBalance);
                cmd.Parameters.AddWithValue("@price", trans.Price);
                cmd.Parameters.AddWithValue("@sessionid", trans.SessionID);
                //cmd.Parameters.AddWithValue("@discountid", null);
                //cmd.Parameters.AddWithValue("@cardid", null);
                cmd.Parameters.AddWithValue("@trainerid", trans.TrainerID);

                cmd.Prepare();

                cmd.ExecuteNonQuery();
            }
            else if (trans.TrainerID == 0)
            {
                ConnectionString myConnection = new ConnectionString();
                string cs = myConnection.cs;

                using var con = new MySqlConnection(cs);
                con.Open();
                string stm = @"INSERT INTO ttransactions(isrefunded, transactiondate, currentbalance, price, sessionid, customerid) VALUES(@isrefunded, @transactiondate, @currentbalance, @price, @sessionid, @customerid)";

                
                //string stm = @"INSERT INTO ttransactions(isrefunded, transactiondate, currentbalance, price, sessionid, discountid, cardid, customerid, trainerid) VALUES(@isrefunded, @transactiondate, @currentbalance, @price, @sessionid, @discountid, @cardid, @customerid, @trainerid)";

                using var cmd = new MySqlCommand(stm, con);
                cmd.Parameters.AddWithValue("@isrefunded", false);
                cmd.Parameters.AddWithValue("@transactiondate", DateTime.Now);
                cmd.Parameters.AddWithValue("@currentbalance", trans.CurrentBalance);
                cmd.Parameters.AddWithValue("@price", trans.Price);
                cmd.Parameters.AddWithValue("@sessionid", trans.SessionID);
                //cmd.Parameters.AddWithValue("@discountid", null);
                //cmd.Parameters.AddWithValue("@cardid", null);
                cmd.Parameters.AddWithValue("@customerid", trans.CustomerID);

                cmd.Prepare();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
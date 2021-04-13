using api.Models.Transactions.Interfaces;
using MySql.Data.MySqlClient;

namespace api.Models.Transactions
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
            
        }
    }
}
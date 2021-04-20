using System;
using API.Models.Creditcards.Interfaces;
using MySql.Data.MySqlClient;

namespace API.Models.Creditcards
{
    public class CreateCC : ICreateCC
    {
        public static void CreateCCTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE tCREDITCARDS(CardID INT AUTO_INCREMENT NOT NULL,CardNo VARCHAR(20) NOT NULL,NameOnCard VARCHAR(50) NOT NULL,SecurityCode VARCHAR(3) NOT NULL,ExpDate DATETIME NOT NULL,CustomerID INT,TrainerID INT,PRIMARY KEY (CardID),FOREIGN KEY (CustomerID) REFERENCES tCUSTOMERS(CustomerID),FOREIGN KEY (TrainerID) REFERENCES tTRAINERS(TrainerID),UNIQUE (CardNo));";


            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }

        void ICreateCC.CreateCC(Creditcard card)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO tcreditcards(cardno, nameoncard, securitycode, expdate, customerid, trainerid) VALUES(@cardno, @nameoncard, @securitycode, @expdate, @customerid, @trainerid)";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@cardno", card.CardNo);
            cmd.Parameters.AddWithValue("@nameoncard", card.NameOnCard);
            cmd.Parameters.AddWithValue("@securitycode", card.SecurityCode);
            cmd.Parameters.AddWithValue("@expdate", card.ExpDate);
            cmd.Parameters.AddWithValue("@customerid", card.CustomerID);
            cmd.Parameters.AddWithValue("@trainerid", card.TrainerID);
            

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}
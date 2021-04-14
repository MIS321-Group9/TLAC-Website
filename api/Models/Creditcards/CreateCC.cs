using api.Models.Creditcards.Interfaces;
using MySql.Data.MySqlClient;

namespace api.Models.Creditcards
{
    public class CreateCC : ICreateCC
    {
        public static void CreateCCTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE tCREDITCARDS(CardID INT AUTO_INCREMENT NOT NULL,CardNo INT NOT NULL,NameOnCard VARCHAR(50) NOT NULL,SecurityCode INT NOT NULL,ExpDate DATETIME NOT NULL,CustomerID INT,TrainerID INT,PRIMARY KEY (CardID),FOREIGN KEY (CustomerID) REFERENCES tCUSTOMERS(CustomerID),FOREIGN KEY (TrainerID) REFERENCES tTRAINERS(TrainerID),UNIQUE (CardNo));";


            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }

        void ICreateCC.CreateCC(Creditcard card)
        {
            
        }
    }
}
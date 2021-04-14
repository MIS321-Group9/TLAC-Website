
using MySql.Data.MySqlClient;

namespace api.Models.Creates
{
    public class CreateCreates
    {
        public static void CreateCreatesTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE tCreates(AdminID INT NOT NULL,EventID INT NOT NULL,PRIMARY KEY (EventID, AdminID),FOREIGN KEY (EventID) REFERENCES tEVENTS(EventID),FOREIGN KEY (AdminID) REFERENCES tADMINS(AdminID));";
            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }
    }
}
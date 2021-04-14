
using MySql.Data.MySqlClient;

namespace api.Models.Edits
{
    public class CreateEdits
    {
        public static void CreateEditsTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE tEdits(AdminID INT NOT NULL,SessionID INT NOT NULL,PRIMARY KEY (AdminID, SessionID),FOREIGN KEY (AdminID) REFERENCES tADMINS(AdminID),FOREIGN KEY (SessionID) REFERENCES tSESSIONS(SessionID));";
            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }
    }
}


using MySql.Data.MySqlClient;

namespace api.Models.Edits
{
    public class DeleteEdits
    {
        public static void DeleteEditsTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"DROP TABLE IF EXISTS tedits";

            using var cmd = new MySqlCommand(stm, con);
            cmd.ExecuteNonQuery();
        }
    }
}


using MySql.Data.MySqlClient;

namespace api.Models.Creates
{
    public class DeleteCreates
    {
        public static void DeleteCreatesTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"DROP TABLE IF EXISTS tcreates";

            using var cmd = new MySqlCommand(stm, con);
            cmd.ExecuteNonQuery();
        }
    }
}
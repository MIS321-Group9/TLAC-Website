using api.Models.Customers.Interfaces;
using MySql.Data.MySqlClient;

namespace api.Models.Customers
{
    public class DeleteCust : IDeleteCust
    {
        public static void DeleteCustTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"DROP TABLE IF EXISTS tcustomers";

            using var cmd = new MySqlCommand(stm, con);
            cmd.ExecuteNonQuery();
        }

        void IDeleteCust.DeleteCust(int CustomerID)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $"DELETE FROM tcustomers WHERE id={CustomerID}";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}
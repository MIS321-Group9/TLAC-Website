using API.Models.Discounts.Interfaces;
using MySql.Data.MySqlClient;

namespace API.Models.Discounts
{
    public class DeleteDis : IDeleteDis
    {
        public static void DeleteDisTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"DROP TABLE IF EXISTS tdiscounts";

            using var cmd = new MySqlCommand(stm, con);
            cmd.ExecuteNonQuery();
        }

        void IDeleteDis.DeleteDis(int DiscountID)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $"DELETE FROM tdiscounts WHERE discountid={DiscountID}";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}
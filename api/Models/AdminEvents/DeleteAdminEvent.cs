using api.Models.AdminEvents.Interfaces;
using MySql.Data.MySqlClient;

namespace api.Models.AdminEvents
{
    public class DeleteAdminEvent : IDeleteAdminEvent
    {
        public static void DeleteAdminEventTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"DROP TABLE IF EXISTS tevents";

            using var cmd = new MySqlCommand(stm, con);
            cmd.ExecuteNonQuery();
        }

        void IDeleteAdminEvent.DeleteAdminEvent(int EventID)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $"DELETE FROM tevents WHERE id={EventID}";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}
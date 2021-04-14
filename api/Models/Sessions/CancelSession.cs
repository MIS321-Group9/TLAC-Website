using api.Models.Sessions.Interfaces;
using MySql.Data.MySqlClient;

namespace api.Models.Sessions
{
    public class CancelSession : ICancelSession
    {
        void ICancelSession.CancelSession(Session session, int SessionID)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $@"UPDATE tsessions iscanceled=@iscanceled WHERE sessionid={SessionID}";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@iscanceled", session.IsCanceled);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}
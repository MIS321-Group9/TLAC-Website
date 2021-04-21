using API.Models.Sessions.Interfaces;
using MySql.Data.MySqlClient;

namespace API.Models.Sessions
{
    public class CancelSession : ICancelSession
    {
        void ICancelSession.CancelSession(int SessionID)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $@"UPDATE tsessions SET iscanceled=True, customerid=null WHERE sessionid={SessionID}";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}
using API.Models.Sessions.Interfaces;
using MySql.Data.MySqlClient;

namespace API.Models.Sessions
{
    public class BookSession : IBookSession
    {
        void IBookSession.BookSession(int CustomerID, int SessionID)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $@"UPDATE tsessions SET customerid={CustomerID} WHERE sessionid={SessionID}";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}
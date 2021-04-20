using API.Models.Sessions.Interfaces;
using MySql.Data.MySqlClient;

namespace API.Models.Sessions
{
    public class BookSession : IBookSession
    {
        void IBookSession.BookSession(Session session, int SessionID)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $@"UPDATE tsessions SET customerid=@customerid WHERE sessionid={SessionID}";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@customerid", session.CustomerID);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}
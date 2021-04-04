using System.Collections.Generic;
using api.Models.Sessions.Interfaces;
using api.Models;

namespace api.Models.Sessions
{
    public class ReadSessionData : IReadAllSessionData, IReadSession
    {
        public List<Session> ReadAllSession()
        {
            List<Session> allSessions = new List<Session>();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM sessions ORDER BY DateOfSession DESC";
            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                allSessions.Add(new Session(){});
            }

            return allSessions;
        }

        public Session ReadSession(int Id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM sessions WHERE sessionId = @id";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id",Id);
            cmd.Prepare();

            using MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();

            return new Session(){};
        }
    }
}
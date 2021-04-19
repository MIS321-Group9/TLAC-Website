using System.Collections.Generic;
using api.Models.Sessions.Interfaces;
using api.Models;
using MySql.Data.MySqlClient;

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

            string stm = "SELECT * FROM tsessions ORDER BY DateOfSession DESC";
            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                allSessions.Add(new Session(){
                    SessionID=rdr.GetInt32(0),
                    SessionLength=rdr.GetInt32(1),
                    DateCreated=rdr.GetDateTime(2),
                    DateOfSession=rdr.GetDateTime(3),
                    PriceOfSession=rdr.GetDouble(4),
                    SessionDescription=rdr.GetString(5),
                    IsCanceled=rdr.GetBoolean(6),
                    CustomerID=rdr.GetInt32(7),
                    TrainerID=rdr.GetInt32(8),
                    AdminID=rdr.GetInt32(9)
                });
            }

            return allSessions;
        }

        public Session ReadSession(int SessionID)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM tsessions WHERE sessionid = @id";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id",SessionID);
            cmd.Prepare();

            using MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();

            return new Session(){
                SessionID=rdr.GetInt32(0),
                SessionLength=rdr.GetInt32(1),
                DateCreated=rdr.GetDateTime(2),
                DateOfSession=rdr.GetDateTime(3),
                PriceOfSession=rdr.GetDouble(4),
                SessionDescription=rdr.GetString(5),
                IsCanceled=rdr.GetBoolean(6),
                CustomerID=rdr.GetInt32(7),
                TrainerID=rdr.GetInt32(8),
                AdminID=rdr.GetInt32(9)
            };
        }
    }
}
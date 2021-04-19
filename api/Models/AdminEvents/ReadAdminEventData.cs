using System.Collections.Generic;
using api.Models.AdminEvents.Interfaces;
using MySql.Data.MySqlClient;

namespace api.Models.AdminEvents
{
    public class ReadAdminEventData : IReadAllAdminEventData, IReadAdminEvent
    {
        public List<AdminEvent> ReadAllAdminEvent()
        {
            List<AdminEvent> allEvents = new List<AdminEvent>();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM tevents";
            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                allEvents.Add(new AdminEvent(){
                    EventID=rdr.GetInt32(0), 
                    EventDescription=rdr.GetString(1), 
                    DateOfEvent=rdr.GetDateTime(2), 
                    EventLength=rdr.GetInt32(3),
                    IsCanceled=rdr.GetBoolean(4),
                    AdminID=rdr.GetInt32(5)
                });
            }

            return allEvents;
        }

        public AdminEvent ReadAdminEvent(int EventID)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM tevents WHERE eventid = @id";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id",EventID);
            cmd.Prepare();

            using MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();

            return new AdminEvent(){
                EventID=rdr.GetInt32(0), 
                EventDescription=rdr.GetString(1), 
                DateOfEvent=rdr.GetDateTime(2), 
                EventLength=rdr.GetInt32(3),
                IsCanceled=rdr.GetBoolean(4),
                AdminID=rdr.GetInt32(5)
            };
        }
    }
}
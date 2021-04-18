using System;
using api.Models.AdminEvents.Interfaces;
using MySql.Data.MySqlClient;

namespace api.Models.AdminEvents
{
    public class CreateAdminEvent : ICreateAdminEvent
    {
        public static void CreateAdminEventTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE tEVENTS(EventID INT AUTO_INCREMENT NOT NULL,EventDescription TEXT(300) NOT NULL,DateOfEvent DATETIME NOT NULL,EventLength INT NOT NULL, IsCanceled BOOLEAN NOT NULL, AdminID INT NOT NULL, PRIMARY KEY (EventID), FOREIGN KEY (AdminID) REFERENCES tADMINS(AdminID));";
            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }

        void ICreateAdminEvent.CreateAdminEvent(AdminEvent adminEvent)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO tevents(eventdescription, dateofevent, eventlength, iscanceled, adminid) VALUES(@eventdescription, @dateofevent, @eventlength, @iscanceled, @adminid)";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@eventdescription", adminEvent.EventDescription);
            cmd.Parameters.AddWithValue("@dateofevent", adminEvent.DateOfEvent);
            cmd.Parameters.AddWithValue("@eventlength", adminEvent.EventLength);
            cmd.Parameters.AddWithValue("@iscanceled", adminEvent.IsCanceled);
            cmd.Parameters.AddWithValue("@adminid", adminEvent.AdminID);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}
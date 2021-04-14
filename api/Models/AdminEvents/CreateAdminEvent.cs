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

            string stm = @"CREATE TABLE tEVENTS(EventID INT AUTO_INCREMENT NOT NULL,EventDescription TEXT(300) NOT NULL,DateOfEvent DATETIME NOT NULL,EventLength INT NOT NULL,PRIMARY KEY (EventID));";
            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }

        void ICreateAdminEvent.CreateAdminEvent(AdminEvent adminEvent)
        {
            
        }
    }
}
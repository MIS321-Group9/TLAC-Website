using api.Models.AdminEvents.Interfaces;
using MySql.Data.MySqlClient;

namespace api.Models.AdminEvents
{
    public class ModifyAdminEvent : IModifyAdminEvent
    {
        public void SaveAdminEvent(AdminEvent adminEvent, int EventID)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $@"UPDATE tevents SET eventdescription=@eventdescription, dateofevent=@dateofevent, eventlength=@eventlength WHERE eventid={EventID}";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@eventdescription", adminEvent.EventDescription);
            cmd.Parameters.AddWithValue("@dateofevent", adminEvent.DateOfEvent);
            cmd.Parameters.AddWithValue("@eventlength", adminEvent.EventLength);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}
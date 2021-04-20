using API.Models.AdminEvents.Interfaces;
using API.Models.Admins;
using MySql.Data.MySqlClient;

namespace API.Models.AdminEvents
{
    public class ModifyAdminEvent : IModifyAdminEvent
    {
        public void SaveAdminEvent(AdminEvent adminEvent, int EventID)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $@"UPDATE tevents SET eventdescription=@eventdescription, dateofevent=@dateofevent, eventlength=@eventlength, iscanceled=@iscanceled, adminid=@adminid WHERE eventid={EventID}";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@eventdescription", adminEvent.EventDescription);
            cmd.Parameters.AddWithValue("@dateofevent", adminEvent.DateOfEvent);
            cmd.Parameters.AddWithValue("@eventlength", adminEvent.EventLength);
            cmd.Parameters.AddWithValue("@iscanceled", adminEvent.IsCanceled);
            cmd.Parameters.AddWithValue("@adminid", adminEvent.AdminID);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }

        public void CancelAdminEvent(Admin admin, int EventID)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $@"UPDATE tevents SET iscanceled=True, adminid=@adminid WHERE eventid={EventID}";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@adminid", admin.ID);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}
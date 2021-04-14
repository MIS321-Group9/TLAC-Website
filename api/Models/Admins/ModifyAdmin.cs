using api.Models.Admins.Interfaces;
using MySql.Data.MySqlClient;

namespace api.Models.Admins
{
    public class ModifyAdmin : IModifyAdmin
    {
        public void SaveAdmin(Admin admin, int AdminID)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $@"UPDATE tadmins SET admincode=@admincode, adminpassword=@adminpassword WHERE adminid={AdminID}";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@admincode", admin.AdminCode);
            cmd.Parameters.AddWithValue("@adminpassword", admin.AdminPassword);
            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}
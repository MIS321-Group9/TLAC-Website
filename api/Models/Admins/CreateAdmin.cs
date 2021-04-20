using API.Models.Admins.Interfaces;
using MySql.Data.MySqlClient;

namespace API.Models.Admins
{
    public class CreateAdmin : ICreateAdmin
    {
        public static void CreateAdminTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE tADMINS(AdminID INT AUTO_INCREMENT NOT NULL,AdminEmail VARCHAR(20) NOT NULL,AdminPassword VARCHAR(20) NOT NULL,PRIMARY KEY (AdminID),UNIQUE (AdminEmail));";
            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }

        void ICreateAdmin.CreateAdmin(Admin admin)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO tadmins(adminemail, adminpassword) VALUES(@adminemail, @adminpassword)";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@adminemail", admin.AdminEmail);
            cmd.Parameters.AddWithValue("@adminpassword", admin.AdminPassword);
            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}
using api.Models.Admins.Interfaces;
using MySql.Data.MySqlClient;

namespace api.Models.Admins
{
    public class CreateAdmin : ICreateAdmin
    {
        public static void CreateAdminTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE tADMINS(AdminID INT AUTO_INCREMENT NOT NULL,AdminCode VARCHAR(20) NOT NULL,AdminPassword VARCHAR(20) NOT NULL,PRIMARY KEY (AdminID),UNIQUE (AdminCode));";
            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }

        void ICreateAdmin.CreateAdmin(Admin admin)
        {
            
        }
    }
}
using System.Collections.Generic;
using API.Models.Admins.Interfaces;
using MySql.Data.MySqlClient;

namespace API.Models.Admins
{
    public class ReadAdminData : IReadAllAdminData, IReadAdmin
    {
        public List<Admin> ReadAllAdmin()
        {
            List<Admin> allSessions = new List<Admin>();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM tadmins";
            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                allSessions.Add(new Admin(){
                    ID=rdr.GetInt32(0),
                    AdminEmail=rdr.GetString(1),
                    AdminPassword=rdr.GetString(1)
                });
            }

            return allSessions;
        }

        public Admin ReadAdmin(int AdminID)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM tadmins WHERE adminid = @id";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id",AdminID);
            cmd.Prepare();

            using MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();

            return new Admin(){
                ID=rdr.GetInt32(0),
                AdminEmail=rdr.GetString(1),
                AdminPassword=rdr.GetString(1)
            };
        }

        public Admin LoginAdmin(string Email, string Password)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM tadmins WHERE adminemail=@adminemail AND adminpassword=@adminpassword";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@adminemail",Email.ToLower());
            cmd.Parameters.AddWithValue("@adminpassword",Password);
            cmd.Prepare();

            using MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();

            return new Admin(){
                ID=rdr.GetInt32(0),
                AdminEmail=rdr.GetString(1),
                AdminPassword=rdr.GetString(1)
            };
        }
    }
}
using System.Collections.Generic;
using api.Models.Admins.Interfaces;
using MySql.Data.MySqlClient;

namespace api.Models.Admins
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

            string stm = "SELECT * FROM admins";
            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                allSessions.Add(new Admin(){});
            }

            return allSessions;
        }

        public Admin ReadAdmin(int AdminID)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM admins WHERE adminID = @id";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id",AdminID);
            cmd.Prepare();

            using MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();

            return new Admin(){};
        }
    }
}
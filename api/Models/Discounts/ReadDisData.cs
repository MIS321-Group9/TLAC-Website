using System.Collections.Generic;
using api.Models.Discounts.Interfaces;
using MySql.Data.MySqlClient;

namespace api.Models.Discounts
{
    public class ReadDisData : IReadAllDisData, IReadDis
    {
        public List<Discount> ReadAllDis()
        {
            List<Discount> allSessions = new List<Discount>();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM tdiscounts";
            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                allSessions.Add(new Discount(){});
            }

            return allSessions;
        }

        public Discount ReadDis(int DiscountID)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM tdiscounts WHERE discountid = @id";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id",DiscountID);
            cmd.Prepare();

            using MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();

            return new Discount(){};
        }
    }
}
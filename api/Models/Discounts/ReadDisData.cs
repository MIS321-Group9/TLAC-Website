using System.Collections.Generic;
using API.Models.Discounts.Interfaces;
using MySql.Data.MySqlClient;

namespace API.Models.Discounts
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
                allSessions.Add(new Discount(){
                    DiscountID=rdr.GetInt32(0),
                    DiscountCode=rdr.GetString(1),
                    IsApplied=rdr.GetBoolean(2),
                    PercentDiscounted=rdr.GetDouble(3),
                    AdminID=rdr.GetInt32(4),
                    CustomerID=rdr.GetInt32(5)
                });
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

            return new Discount(){
                DiscountID=rdr.GetInt32(0),
                DiscountCode=rdr.GetString(1),
                IsApplied=rdr.GetBoolean(2),
                PercentDiscounted=rdr.GetDouble(3),
                AdminID=rdr.GetInt32(4),
                CustomerID=rdr.GetInt32(5)
            };
        }
    }
}
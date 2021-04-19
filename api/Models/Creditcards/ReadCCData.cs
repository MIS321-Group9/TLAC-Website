using System.Collections.Generic;
using api.Models.Creditcards.Interfaces;
using MySql.Data.MySqlClient;

namespace api.Models.Creditcards
{
    public class ReadCCData : IReadAllCCData, IReadCC
    {
        public List<Creditcard> ReadAllCC()
        {
            List<Creditcard> allSessions = new List<Creditcard>();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM tcreditcards";
            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                allSessions.Add(new Creditcard(){
                    CardID=rdr.GetInt32(0),
                    CardNo=rdr.GetString(1),
                    NameOnCard=rdr.GetString(2),
                    SecurityCode=rdr.GetString(3),
                    ExpDate=rdr.GetDateTime(4),
                    CustomerID=rdr.GetInt32(5),
                    TrainerID=rdr.GetInt32(6)
                });
            }

            return allSessions;
        }

        public Creditcard ReadCC(int CardID)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM tcreditcards WHERE cardId = @id";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id",CardID);
            cmd.Prepare();

            using MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();

            return new Creditcard(){
                CardID=rdr.GetInt32(0),
                CardNo=rdr.GetString(1),
                NameOnCard=rdr.GetString(2),
                SecurityCode=rdr.GetString(3),
                ExpDate=rdr.GetDateTime(4),
                CustomerID=rdr.GetInt32(5),
                TrainerID=rdr.GetInt32(6)
            };
        }
    }
}
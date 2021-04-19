using System.Collections.Generic;
using api.Models.Customers.Interfaces;
using MySql.Data.MySqlClient;

namespace api.Models.Customers
{
    public class ReadCustData : IReadAllCustData, IReadCust
    {
        public List<Customer> ReadAllCust()
        {
            List<Customer> allSessions = new List<Customer>();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM tcustomers";
            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                allSessions.Add(new Customer(){
                    ID=rdr.GetInt32(0),
                    CustomerFName=rdr.GetString(1),
                    CustomerLName=rdr.GetString(2),
                    CustomerEmail=rdr.GetString(3),
                    CustomerPassword=rdr.GetString(4),
                    CustomerPhoneNo=rdr.GetString(5),
                    CustomerBalance=rdr.GetDouble(6)
                });
            }

            return allSessions;
        }

        public Customer ReadCust(int CustomerID)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM tcustomers WHERE customerid = @id";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id",CustomerID);
            cmd.Prepare();

            using MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();

            return new Customer(){
                ID=rdr.GetInt32(0),
                CustomerFName=rdr.GetString(1),
                CustomerLName=rdr.GetString(2),
                CustomerEmail=rdr.GetString(3),
                CustomerPassword=rdr.GetString(4),
                CustomerPhoneNo=rdr.GetString(5),
                CustomerBalance=rdr.GetDouble(6)
            };
        }

        public Customer LoginCustomer(string Email, string Password)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM tcustomers WHERE customeremail=@customeremail AND customerpassword=@customerpassword";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@customeremail",Email.ToLower());
            cmd.Parameters.AddWithValue("@customerpassword",Password);
            cmd.Prepare();

            using MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();

            return new Customer(){
                ID=rdr.GetInt32(0),
                CustomerFName=rdr.GetString(1),
                CustomerLName=rdr.GetString(2),
                CustomerEmail=rdr.GetString(3),
                CustomerPassword=rdr.GetString(4),
                CustomerPhoneNo=rdr.GetString(5),
                CustomerBalance=rdr.GetDouble(6)
            };
        }
    }
}
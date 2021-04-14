using api.Models.Customers.Interfaces;
using MySql.Data.MySqlClient;

namespace api.Models.Customers
{
    public class ModifyCust : IModifyCust
    {
        public void SaveCust(Customer cust, int CustomerID)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $@"UPDATE tcustomers SET customerfname=@customerfname, customerlname=@customerlname, customerphonenumber=@customerphonenumber, customeremail=@customeremail, customerpassword=@customerpassword, customerbalance=@customerbalance WHERE customerid={CustomerID}";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@customerfname", cust.CustomerFName);
            cmd.Parameters.AddWithValue("@customerlname", cust.CustomerLName);
            cmd.Parameters.AddWithValue("@customerphonenumber", cust.CustomerPhoneNo);
            cmd.Parameters.AddWithValue("@customeremail", cust.CustomerEmail);
            cmd.Parameters.AddWithValue("@customerpassword", cust.CustomerPassword);
            cmd.Parameters.AddWithValue("@customerbalance", cust.CustomerBalance);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}
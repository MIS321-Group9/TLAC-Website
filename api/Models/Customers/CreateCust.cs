using api.Models.Customers.Interfaces;
using MySql.Data.MySqlClient;

namespace api.Models.Customers
{
    public class CreateCust : ICreateCust
    {
        public static void CreateCustTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE tCUSTOMERS(CustomerID INT AUTO_INCREMENT NOT NULL,CustomerFName VARCHAR(20) NOT NULL,CustomerLName VARCHAR(20) NOT NULL,CustomerEmail VARCHAR(40) NOT NULL,CustomerPassword VARCHAR(20) NOT NULL,CustomerPhoneNumber VARCHAR(11) NOT NULL,CustomerBalance DOUBLE NOT NULL,PRIMARY KEY (CustomerID),UNIQUE (CustomerEmail),UNIQUE (CustomerPhoneNumber));";


            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }

        void ICreateCust.CreateCust(Customer cust)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO tcustomers(customerfname, customerlname, customerphonenumber, customeremail, customerpassword, customerbalance) VALUES(@customerfname, @customerlname, @customerphonenumber, @customeremail, @customerpassword, @customerbalance)";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@customerfname", cust.CustomerFName.ToLower());
            cmd.Parameters.AddWithValue("@customerlname", cust.CustomerLName.ToLower());
            cmd.Parameters.AddWithValue("@customerphonenumber", cust.CustomerPhoneNo);
            cmd.Parameters.AddWithValue("@customeremail", cust.CustomerEmail.ToLower());
            cmd.Parameters.AddWithValue("@customerpassword", cust.CustomerPassword);
            cmd.Parameters.AddWithValue("@customerbalance", cust.CustomerBalance);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}
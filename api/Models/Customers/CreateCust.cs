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

            string stm = @"CREATE TABLE tCUSTOMERS(CustomerID INT AUTO_INCREMENT NOT NULL,CustomerFName VARCHAR(20) NOT NULL,CustomerLName VARCHAR(20) NOT NULL,CustomerEmail VARCHAR(40) NOT NULL,CustomerPassword VARCHAR(20) NOT NULL,CustomerPhoneNumber INT NOT NULL,CustomerBalance DOUBLE NOT NULL,PRIMARY KEY (CustomerID),UNIQUE (CustomerEmail),UNIQUE (CustomerPhoneNumber));";


            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }

        void ICreateCust.CreateCust(Customer cust)
        {
            
        }
    }
}
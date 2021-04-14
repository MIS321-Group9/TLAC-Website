using api.Models.Discounts.Interfaces;
using MySql.Data.MySqlClient;

namespace api.Models.Discounts
{
    public class CreateDis : ICreateDis
    {
        public static void CreateDisTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE tDISCOUNTS(DiscountID INT AUTO_INCREMENT NOT NULL,IsApplied BOOLEAN NOT NULL,PercentDiscounted DOUBLE NOT NULL,AdminID INT NOT NULL,CustomerID INT,PRIMARY KEY (DiscountID),FOREIGN KEY (AdminID) REFERENCES tADMINS(AdminID),FOREIGN KEY (CustomerID) REFERENCES tCUSTOMERS(CustomerID));";


            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }

        void ICreateDis.CreateDis(Discount discount)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO tdiscounts(isapplied, percentdiscounted, adminid, customerid) VALUES(@isapplied, @percentdiscounted, @adminid, @customerid)";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@isapplied", discount.IsApplied);
            cmd.Parameters.AddWithValue("@percentdiscounted", discount.PercentDiscounted);
            cmd.Parameters.AddWithValue("@adminid", discount.AdminID);
            cmd.Parameters.AddWithValue("@customerid", discount.CustomerID);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}
using API.Models.Discounts.Interfaces;
using MySql.Data.MySqlClient;

namespace API.Models.Discounts
{
    public class ModifyDis : IModifyDis
    {
        public void SaveDis(Discount discount, int DiscountID)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $@"UPDATE tdiscounts SET discountcode=@discountcode, isapplied=@isapplied, percentdiscounted=@percentdiscounted, adminid=@adminid, customerid=@customerid WHERE discountid={DiscountID}";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@discountcode", discount.DiscountCode);
            cmd.Parameters.AddWithValue("@isapplied", discount.IsApplied);
            cmd.Parameters.AddWithValue("@percentdiscounted", discount.PercentDiscounted);
            cmd.Parameters.AddWithValue("@adminid", discount.AdminID);
            cmd.Parameters.AddWithValue("@customerid", discount.CustomerID);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}
using api.Models.Creditcards.Interfaces;
using MySql.Data.MySqlClient;

namespace api.Models.Creditcards
{
    public class ModifyCC : IModifyCC
    {
        public void SaveCC(Creditcard card, int CardID)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $@"UPDATE tcreditcards SET cardno=@cardno, nameoncard=@nameoncard, securitycode=@securitycode, expdate=@expdate, customerid=@customerid, trainerid=@trainerid WHERE cardid={CardID}";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@cardno", card.CardNo);
            cmd.Parameters.AddWithValue("@nameoncard", card.NameOnCard);
            cmd.Parameters.AddWithValue("@securitycode", card.SecurityCode);
            cmd.Parameters.AddWithValue("@expdate", card.ExpDate);
            cmd.Parameters.AddWithValue("@customerid", card.CustomerID);
            cmd.Parameters.AddWithValue("@trainerid", card.TrainerID);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}
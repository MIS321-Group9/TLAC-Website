using System;
using api.Models.Sessions.Interfaces;
using MySql.Data.MySqlClient;

namespace api.Models.Sessions
{
    public class ModifySession : IModifySession
    {
        public void SaveSession(Session session, int SessionID)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $@"UPDATE tsessions SET sessionlength=@sessionlength, dateofsession=@dateofsession, priceofsession=@priceofsession, sessiondescription=@sessiondescription, iscanceled=@iscanceled, customerid=@customerid, trainerid=@trainerid, adminid=@adminid WHERE sessionid={SessionID}";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@sessionlength", session.SessionLength);
            cmd.Parameters.AddWithValue("@dateofsession", session.DateOfSession);
            cmd.Parameters.AddWithValue("@priceofsession", session.PriceOfSession);
            cmd.Parameters.AddWithValue("@sessopndescription", session.SessionDescription);
            cmd.Parameters.AddWithValue("@iscanceled", session.IsCanceled);
            cmd.Parameters.AddWithValue("@customerid", session.CustomerID);
            cmd.Parameters.AddWithValue("@trainerid", session.TrainerID);
            cmd.Parameters.AddWithValue("@adminid", session.AdminID);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}
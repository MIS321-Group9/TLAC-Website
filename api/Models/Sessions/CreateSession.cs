using System;
using API.Models.Sessions.Interfaces;
using MySql.Data.MySqlClient;

namespace API.Models.Sessions
{
    public class CreateSession : ICreateSession
    {
        public static void CreateSessionTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE tSESSIONS(SessionID INT AUTO_INCREMENT NOT NULL,SessionLength INT NOT NULL,DateCreated DATETIME NOT NULL,DateOfSession DATETIME NOT NULL,PriceOfSession DOUBLE NOT NULL,SessionDescription TEXT(200),IsCanceled BOOLEAN NOT NULL,CustomerID INT,TrainerID INT NOT NULL, AdminID INT, PRIMARY KEY (SessionID),FOREIGN KEY (CustomerID) REFERENCES tCUSTOMERS(CustomerID),FOREIGN KEY (TrainerID) REFERENCES tTRAINERS(TrainerID), FOREIGN KEY (AdminID) REFERENCES tADMINS(AdminID));";


            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }

        void ICreateSession.CreateSession(Session session)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO tsessions(sessionlength, datecreated, dateofsession, priceofsession, sessiondescription, iscanceled, trainerid, adminid) VALUES(@sessionlength, @datecreated, @dateofsession, @priceofsession, @sessiondescription, @iscanceled, @trainerid, @adminid)";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@sessionlength", session.SessionLength);
            cmd.Parameters.AddWithValue("@datecreated", DateTime.Now);
            cmd.Parameters.AddWithValue("@dateofsession", session.DateOfSession);
            cmd.Parameters.AddWithValue("@priceofsession", session.PriceOfSession);
            cmd.Parameters.AddWithValue("@sessiondescription", session.SessionDescription);
            cmd.Parameters.AddWithValue("@iscanceled", false);
            cmd.Parameters.AddWithValue("@trainerid", session.TrainerID);
            cmd.Parameters.AddWithValue("@adminid", session.AdminID);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}
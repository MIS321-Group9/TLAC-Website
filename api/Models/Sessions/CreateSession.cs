using System;
using api.Models.Sessions.Interfaces;
using MySql.Data.MySqlClient;

namespace api.Models.Sessions
{
    public class CreateSession : ICreateSession
    {
        public static void CreateSessionTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE tSESSIONS(SessionID INT AUTO_INCREMENT NOT NULL,SessionLength INT NOT NULL,DateCreated DATETIME NOT NULL,DateOfSession DATETIME NOT NULL,PriceOfSession DOUBLE NOT NULL,SessionDescription TEXT(200),IsCanceled BOOLEAN NOT NULL,CustomerID INT,TrainerID INT NOT NULL,PRIMARY KEY (SessionID),FOREIGN KEY (CustomerID) REFERENCES tCUSTOMERS(CustomerID),FOREIGN KEY (TrainerID) REFERENCES tTRAINERS(TrainerID));";


            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }

        void ICreateSession.CreateSession(Session session)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO tsessions(sessionlength, datecreated, dateofsession, priceofsession, sessiondescription, iscanceled, customerid, trainerid) VALUES(@sessionlength, @datecreated, @dateofsession, @priceofsession, @sessiondescription, @iscanceled, @customerid, @trainerid)";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@sessionlength", session.SessionLength);
            cmd.Parameters.AddWithValue("@datecreated", DateTime.Now);
            cmd.Parameters.AddWithValue("@dateofsession", session.DateOfSession);
            cmd.Parameters.AddWithValue("@priceofsession", session.PriceOfSession);
            cmd.Parameters.AddWithValue("@sessopndescription", session.SessionDescription);
            cmd.Parameters.AddWithValue("@iscanceled", session.IsCanceled);
            cmd.Parameters.AddWithValue("@customerid", session.CustomerID);
            cmd.Parameters.AddWithValue("@trainerid", session.TrainerID);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}
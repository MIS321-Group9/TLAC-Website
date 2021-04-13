using api.Models.Trainers.Interfaces;
using MySql.Data.MySqlClient;

namespace api.Models.Trainers
{
    public class CreateTrainer : ICreateTrainer
    {
        public static void CreateTrainerTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE tTRAINERS(TrainerID INT AUTO_INCREMENT NOT NULL,TrainerFName VARCHAR(20) NOT NULL,TrainerLName VARCHAR(20) NOT NULL,TrainerEmail VARCHAR(40) NOT NULL,TrainerPassword VARCHAR(20) NOT NULL,TrainerPhoneNumber INT NOT NULL,TrainerBalance DOUBLE NOT NULL,IsCertified BOOLEAN NOT NULL,PRIMARY KEY (TrainerID),UNIQUE (TrainerEmail),UNIQUE (TrainerPhoneNumber));";


            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }

        void ICreateTrainer.CreateTrainer(Trainer trainer)
        {
            
        }
    }
}
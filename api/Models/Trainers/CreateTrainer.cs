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

            string stm = @"CREATE TABLE tTRAINERS(TrainerID INT AUTO_INCREMENT NOT NULL,TrainerFName VARCHAR(20) NOT NULL,TrainerLName VARCHAR(20) NOT NULL,TrainerEmail VARCHAR(40) NOT NULL,TrainerPassword VARCHAR(20) NOT NULL,TrainerPhoneNumber VARCHAR(11) NOT NULL,TrainerBalance DOUBLE NOT NULL,IsCertified BOOLEAN NOT NULL,PRIMARY KEY (TrainerID),UNIQUE (TrainerEmail),UNIQUE (TrainerPhoneNumber));";


            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }

        void ICreateTrainer.CreateTrainer(Trainer trainer)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO ttrainers(trainerfname, trainerlname, trainerphonenumber, traineremail, trainerpassword, trainerbalance, iscertified) VALUES(@trainerfname, @trainerlname, @trainerphonenumber, @traineremail, @trainerpassword, @trainerbalance, @iscertified)";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@trainerfname", trainer.TrainerFName);
            cmd.Parameters.AddWithValue("@trainerlname", trainer.TrainerLName);
            cmd.Parameters.AddWithValue("@trainerphonenumber", trainer.TrainerPhoneNo);
            cmd.Parameters.AddWithValue("@traineremail", trainer.TrainerEmail);
            cmd.Parameters.AddWithValue("@trainerpassword", trainer.TrainerPassword);
            cmd.Parameters.AddWithValue("@trainerbalance", trainer.TrainerBalance);
            cmd.Parameters.AddWithValue("@iscertified", trainer.IsCertified);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}
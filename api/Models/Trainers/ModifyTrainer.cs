using api.Models.Trainers.Interfaces;
using MySql.Data.MySqlClient;

namespace api.Models.Trainers
{
    public class ModifyTrainer : IModifyTrainer
    {
        public void SaveTrainer(Trainer trainer, int TrainerID)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $@"UPDATE ttrainers SET trainerfname=@trainerfname, trainerlname=@trainerlname, trainerphonenumber=@trainerphonenumber, traineremail=@traineremail, trainerpassword=@trainerpassword, trainerbalance=@trainerbalance, iscertified=@iscertified WHERE id={TrainerID}";

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
using api.Models.Trainers.Interfaces;
using MySql.Data.MySqlClient;

namespace api.Models.Trainers
{
    public class DeleteTrainer : IDeleteTrainer
    {
        public static void DeleteTrainerTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"DROP TABLE IF EXISTS ttrainers";

            using var cmd = new MySqlCommand(stm, con);
            cmd.ExecuteNonQuery();
        }

        void IDeleteTrainer.DeleteTrainer(int TrainerID)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $"DELETE FROM ttrainer WHERE id={TrainerID}";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}
using System.Collections.Generic;
using API.Models.Trainers.Interfaces;
using MySql.Data.MySqlClient;

namespace API.Models.Trainers
{
    public class ReadTrainerData : IReadAllTrainerData, IReadTrainer
    {
        public List<Trainer> ReadAllTrainer()
        {
             List<Trainer> allTrainers = new List<Trainer>();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM ttrainers";
            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                allTrainers.Add(new Trainer(){
                    ID=rdr.GetInt32(0),
                    TrainerFName=rdr.GetString(1),
                    TrainerLName=rdr.GetString(2),
                    TrainerEmail=rdr.GetString(3),
                    TrainerPassword=rdr.GetString(4),
                    TrainerPhoneNo=rdr.GetString(5),
                    TrainerBalance=rdr.GetDouble(6),
                    IsCertified=rdr.GetBoolean(7)
                });
            }

            return allTrainers;
        }

        public Trainer ReadTrainer(int TrainerID)
        {
             ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM ttrainers WHERE trainerid = @id";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id",TrainerID);
            cmd.Prepare();

            using MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();

            return new Trainer(){
                ID=rdr.GetInt32(0),
                TrainerFName=rdr.GetString(1),
                TrainerLName=rdr.GetString(2),
                TrainerEmail=rdr.GetString(3),
                TrainerPassword=rdr.GetString(4),
                TrainerPhoneNo=rdr.GetString(5),
                TrainerBalance=rdr.GetDouble(6),
                IsCertified=rdr.GetBoolean(7)
            };
        }

        public Trainer LoginTrainer(string Email, string Password)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM ttrainers WHERE traineremail=@traineremail AND trainerpassword=@trainerpassword";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@traineremail",Email.ToLower());
            cmd.Parameters.AddWithValue("@trainerpassword",Password);
            cmd.Prepare();

            using MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();

            return new Trainer(){
                ID=rdr.GetInt32(0),
                TrainerFName=rdr.GetString(1),
                TrainerLName=rdr.GetString(2),
                TrainerEmail=rdr.GetString(3),
                TrainerPassword=rdr.GetString(4),
                TrainerPhoneNo=rdr.GetString(5),
                TrainerBalance=rdr.GetDouble(6),
                IsCertified=rdr.GetBoolean(7)
            };
        }
    }
}
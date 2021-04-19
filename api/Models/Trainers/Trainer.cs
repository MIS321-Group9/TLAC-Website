using api.Models.Trainers.Interfaces;
using api.Models.Users;

namespace api.Models.Trainers
{
    public class Trainer : User
    {
        public int ID {get; set;}
        public string TrainerFName {get; set;}
        public string TrainerLName {get; set;}
        public double TrainerBalance {get; set;}
        public string TrainerPhoneNo {get; set;}
        public string TrainerEmail {get; set;}
        public string TrainerPassword {get; set;}
        public bool IsCertified {get; set;}
        public IModifyTrainer Save {get; set;}
        public IDeleteTrainer Delete {get; set;}
        public ICreateTrainer Create {get; set;}
        public Trainer()
        {
            Save = new ModifyTrainer();
            Delete = new DeleteTrainer();
            Create = new CreateTrainer();
        }
    }
}
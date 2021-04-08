using api.Models.Trainers.Interfaces;

namespace api.Models.Trainers
{
    public class Trainer
    {
        public int Id {get; set;}
        public string TrainerFName {get; set;}
        public string TrainerLName {get; set;}
        public double TrainerBalance {get; set;}
        public int PhoneNo {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public bool IsCertified {get; set;}
        public IModifyTrainer Save {get; set;}
        public IDeleteTrainer Delete {get; set;}
        public ICreateTrainer Create {get; set;}
    }
}
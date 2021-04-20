namespace API.Models.Trainers.Interfaces
{
    public interface IReadTrainer
    {
        public Trainer ReadTrainer(int TrainerID);
        public Trainer LoginTrainer(string Email, string Password);
    }
}
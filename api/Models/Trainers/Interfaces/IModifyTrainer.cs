namespace API.Models.Trainers.Interfaces
{
    public interface IModifyTrainer
    {
        public void SaveTrainer(Trainer trainer, int TrainerID);
    }
}
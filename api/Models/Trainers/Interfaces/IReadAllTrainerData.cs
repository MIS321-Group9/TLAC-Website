using System.Collections.Generic;

namespace API.Models.Trainers.Interfaces
{
    public interface IReadAllTrainerData
    {
        public List<Trainer> ReadAllTrainer();
    }
}
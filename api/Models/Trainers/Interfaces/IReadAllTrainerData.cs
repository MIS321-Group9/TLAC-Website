using System.Collections.Generic;

namespace api.Models.Trainers.Interfaces
{
    public interface IReadAllTrainerData
    {
        public List<Trainer> ReadAllTrainer();
    }
}
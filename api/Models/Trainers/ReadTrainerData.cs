using System.Collections.Generic;
using api.Models.Trainers.Interfaces;

namespace api.Models.Trainers
{
    public class ReadTrainerData : IReadAllTrainerData, IReadTrainer
    {
        public List<Trainer> ReadAllTrainer()
        {

        }

        public Trainer ReadTrainer(int Id)
        {
            
        }
    }
}
using System.Collections.Generic;

namespace API.Models.Creditcards.Interfaces
{
    public interface IReadAllCCData
    {
        public List<Creditcard> ReadAllCC();
    }
}
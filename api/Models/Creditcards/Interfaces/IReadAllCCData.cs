using System.Collections.Generic;

namespace api.Models.Creditcards.Interfaces
{
    public interface IReadAllCCData
    {
        public List<Creditcard> ReadAllCC();
    }
}
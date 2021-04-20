using System.Collections.Generic;

namespace API.Models.Discounts.Interfaces
{
    public interface IReadAllDisData
    {
        public List<Discount> ReadAllDis();
    }
}
using System.Collections.Generic;

namespace api.Models.Discounts.Interfaces
{
    public interface IReadAllDisData
    {
        public List<Discount> ReadAllDis();
    }
}
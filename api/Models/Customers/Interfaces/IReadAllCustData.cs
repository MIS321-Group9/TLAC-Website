using System.Collections.Generic;

namespace api.Models.Customers.Interfaces
{
    public interface IReadAllCustData
    {
        public List<Customer> ReadAllCust();
    }
}
using System.Collections.Generic;

namespace API.Models.Customers.Interfaces
{
    public interface IReadAllCustData
    {
        public List<Customer> ReadAllCust();
    }
}
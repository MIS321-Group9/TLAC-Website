using System.Collections.Generic;

namespace api.Models.Customer.Interfaces
{
    public interface IReadAllCustData
    {
        public List<Customer> ReadAllCust();
    }
}
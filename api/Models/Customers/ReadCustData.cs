using System.Collections.Generic;
using api.Models.Customers.Interfaces;

namespace api.Models.Customers
{
    public class ReadCustData : IReadAllCustData, IReadCust
    {
        public List<Customer> ReadAllCust()
        {

        }

        public Customer ReadCust(int Id)
        {
            
        }
    }
}
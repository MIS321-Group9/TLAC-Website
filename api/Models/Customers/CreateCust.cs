using api.Models.Customers.Interfaces;

namespace api.Models.Customers
{
    public class CreateCust : ICreateCust
    {
        public static void CreateCustTable()
        {

        }

        void ICreateCust.CreateCust(Customer cust)
        {
            
        }
    }
}
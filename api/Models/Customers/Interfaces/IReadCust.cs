namespace api.Models.Customers.Interfaces
{
    public interface IReadCust
    {
        public Customer ReadCust(int CustomerID);
        public Customer LoginCustomer(string Email, string Password);
    }
}
namespace API.Models.Customers.Interfaces
{
    public interface IModifyCust
    {
        public void SaveCust(Customer cust, int CustomerID);
    }
}
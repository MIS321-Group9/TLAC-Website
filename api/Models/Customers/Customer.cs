using api.Models.Customers.Interfaces;

namespace api.Models.Customers
{
    public class Customer
    {
        public int CustomerID {get; set;}
        public string CustomerFName {get; set;}
        public string CustomerLName {get; set;}
        public double CustomerBalance {get; set;}
        public int CustomerPhoneNo {get; set;}
        public string CustomerEmail {get; set;}
        public string CustomerPassword {get; set;}
        public IModifyCust Save {get; set;}
        public IDeleteCust Delete {get; set;}
        public ICreateCust Create {get; set;}
        public Customer()
        {
            Save = new ModifyCust();
            Delete = new DeleteCust();
            Create = new CreateCust();
        }
    }
}
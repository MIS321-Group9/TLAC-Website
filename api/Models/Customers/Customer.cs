using api.Models.Customers.Interfaces;

namespace api.Models.Customers
{
    public class Customer
    {
        public int Id {get; set;}
        public string CustomerFName {get; set;}
        public string CustomerLName {get; set;}
        public double CustomerBalance {get; set;}
        public int PhoneNo {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public IModifyCust Save {get; set;}
        public IDeleteCust Delete {get; set;}
        public ICreateCust Create {get; set;}
    }
}
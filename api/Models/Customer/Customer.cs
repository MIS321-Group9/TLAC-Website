using api.Models.Customer.Interfaces;

namespace api.Models.Customer
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
using api.Models.Admins.Interfaces;

namespace api.Models.Admins
{
    public class Admin
    {
        public int Id {get; set;}
        public string AdminCode {get; set;}
        public string Password {get; set;}
        public IModifyAdmin Save {get; set;}
        public IDeleteAdmin Delete {get; set;}
        public ICreateAdmin Create {get; set;}
    }
}
using API.Models.Admins.Interfaces;
using API.Models.Users;

namespace API.Models.Admins
{
    public class Admin : User
    {
        public int ID {get; set;}
        public string AdminEmail {get; set;}
        public string AdminPassword {get; set;}
        public IModifyAdmin Save {get; set;}
        public IDeleteAdmin Delete {get; set;}
        public ICreateAdmin Create {get; set;}
        public Admin()
        {
            Save = new ModifyAdmin();
            Delete = new DeleteAdmin();
            Create = new CreateAdmin();
        }
    }
}
using api.Models.Admins.Interfaces;

namespace api.Models.Admins
{
    public class Admin
    {
        public int AdminID {get; set;}
        public string AdminCode {get; set;}
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
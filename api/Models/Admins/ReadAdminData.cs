using System.Collections.Generic;
using api.Models.Admins.Interfaces;

namespace api.Models.Admins
{
    public class ReadAdminData : IReadAllAdminData, IReadAdmin
    {
        public List<Admin> ReadAllAdmin()
        {

        }

        public Admin ReadAdmin(int Id)
        {
            
        }
    }
}
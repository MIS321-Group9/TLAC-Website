using System.Collections.Generic;

namespace API.Models.Admins.Interfaces
{
    public interface IReadAllAdminData
    {
        public List<Admin> ReadAllAdmin();
    }
}
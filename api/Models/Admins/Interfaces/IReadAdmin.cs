using System.Collections.Generic;

namespace api.Models.Admins.Interfaces
{
    public interface IReadAllAdminData
    {
        public List<Admin> ReadAllAdmin();
    }
}
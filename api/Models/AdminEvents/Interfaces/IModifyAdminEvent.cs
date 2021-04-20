using API.Models.Admins;

namespace API.Models.AdminEvents.Interfaces
{
    public interface IModifyAdminEvent
    {
        public void SaveAdminEvent(AdminEvent adminEvent, int EventID);
        public void CancelAdminEvent(Admin admin, int EventID);
    }
}
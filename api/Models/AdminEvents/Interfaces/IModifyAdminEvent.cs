namespace api.Models.AdminEvents.Interfaces
{
    public interface IModifyAdminEvent
    {
        public void SaveAdminEvent(AdminEvent adminEvent, int EventID);
    }
}
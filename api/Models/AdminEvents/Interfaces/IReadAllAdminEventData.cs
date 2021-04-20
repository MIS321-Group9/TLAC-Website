namespace API.Models.AdminEvents.Interfaces
{
    public interface IReadAdminEvent
    {
        public AdminEvent ReadAdminEvent(int EventID);
    }
}
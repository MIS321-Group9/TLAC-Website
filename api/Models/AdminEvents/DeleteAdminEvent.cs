using api.Models.AdminEvents.Interfaces;

namespace api.Models.AdminEvents
{
    public class DeleteAdminEvent : IDeleteAdminEvent
    {
        public static void DeleteAdminEventTable()
        {

        }

        void IDeleteAdminEvent.DeleteAdminEvent(int EventID)
        {
            
        }
    }
}
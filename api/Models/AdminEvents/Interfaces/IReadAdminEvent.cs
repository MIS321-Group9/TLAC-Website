using System.Collections.Generic;

namespace api.Models.AdminEvents.Interfaces
{
    public interface IReadAllAdminEventData
    {
        public List<AdminEvent> ReadAllAdminEvent();
    }
}
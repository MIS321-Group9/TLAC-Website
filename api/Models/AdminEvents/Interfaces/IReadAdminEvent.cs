using System.Collections.Generic;

namespace API.Models.AdminEvents.Interfaces
{
    public interface IReadAllAdminEventData
    {
        public List<AdminEvent> ReadAllAdminEvent();
    }
}
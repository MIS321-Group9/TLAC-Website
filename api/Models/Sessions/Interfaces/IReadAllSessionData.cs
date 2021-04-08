using System.Collections.Generic;

namespace api.Models.Sessions.Interfaces
{
    public interface IReadAllSessionData
    {
        public List<Session> ReadAllSession();
    }
}
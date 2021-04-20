using System.Collections.Generic;

namespace API.Models.Sessions.Interfaces
{
    public interface IReadAllSessionData
    {
        public List<Session> ReadAllSession();
    }
}
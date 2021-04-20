namespace API.Models.Sessions.Interfaces
{
    public interface IModifySession
    {
        public void SaveSession(Session session, int SessionID);
    }
}
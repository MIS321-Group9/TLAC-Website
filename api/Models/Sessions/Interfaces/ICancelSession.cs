namespace api.Models.Sessions.Interfaces
{
    public interface ICancelSession
    {
        public void CancelSession(Session session, int Id);
    }
}
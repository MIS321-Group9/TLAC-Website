namespace API.Models.Sessions.Interfaces
{
    public interface IBookSession
    {
        public void BookSession(int CustomerID, int SessionID);
    }
}
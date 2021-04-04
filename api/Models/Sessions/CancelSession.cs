using api.Models.Sessions.Interfaces;

namespace api.Models.Sessions
{
    public class CancelSession : ICancelSession
    {
        void ICancelSession.CancelSession(Session session, int Id)
        {
            
        }
    }
}
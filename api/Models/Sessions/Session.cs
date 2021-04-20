using System;
using API.Models.Sessions.Interfaces;

namespace API.Models.Sessions
{
    public class Session
    {
        public int SessionID {get; set;}
        public bool IsCanceled {get; set;}
        public DateTime DateCreated {get; set;}
        public DateTime DateOfSession {get; set;}
        public double PriceOfSession {get; set;}
        public int SessionLength {get; set;}
        public string SessionDescription {get; set;}
        public int TrainerID {get; set;}
        public int CustomerID {get; set;}
        public int AdminID {get; set;}
        public IModifySession Save {get; set;}
        public ICreateSession Create {get; set;}
        public IBookSession Book {get; set;}
        public IDeleteSession Delete {get; set;}
        public ICancelSession Cancel {get; set;}
        public Session()
        {
            Save = new ModifySession();
            Delete = new DeleteSession();
            Create = new CreateSession();
            Book = new BookSession();
            Cancel = new CancelSession();
        }
    }
}
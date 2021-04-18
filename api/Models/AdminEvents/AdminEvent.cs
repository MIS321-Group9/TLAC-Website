using System;
using api.Models.AdminEvents.Interfaces;

namespace api.Models.AdminEvents
{
    public class AdminEvent
    {
        public int EventID {get; set;}
        public string EventDescription {get; set;}
        public DateTime DateOfEvent {get; set;}
        public int EventLength {get; set;} // length is in hours
        public bool IsCanceled {get; set;}
        public int AdminID {get; set;}
        public IModifyAdminEvent Save {get; set;}
        public IDeleteAdminEvent Delete {get; set;}
        public ICreateAdminEvent Create {get; set;}
        public AdminEvent()
        {
            Save = new ModifyAdminEvent();
            Delete = new DeleteAdminEvent();
            Create = new CreateAdminEvent();
        }
    }
}
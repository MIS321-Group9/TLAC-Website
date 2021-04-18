using System;
using api.Models.Creditcards.Interfaces;

namespace api.Models.Creditcards
{
    public class Creditcard
    {
        public int CardID {get; set;}
        public string CardNo {get; set;}
        public string NameOnCard {get; set;}
        public string SecurityCode {get; set;}
        public DateTime ExpDate {get; set;}
        public int CustomerID {get; set;}
        public int TrainerID {get; set;}
        public IModifyCC Save {get; set;}
        public IDeleteCC Delete {get; set;}
        public ICreateCC Create {get; set;}
        public Creditcard()
        {
            Save = new ModifyCC();
            Delete = new DeleteCC();
            Create = new CreateCC();
        }
    }
}
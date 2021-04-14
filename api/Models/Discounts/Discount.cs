using System;
using api.Models.Discounts.Interfaces;

namespace api.Models.Discounts
{
    public class Discount
    {
        public int DiscountID {get; set;}
        public bool IsApplied {get; set;}
        public double PercentDiscounted {get; set;}
        public int AdminID {get; set;}
        public int CustomerID {get; set;}
        public IModifyDis Save {get; set;}
        public IDeleteDis Delete {get; set;}
        public ICreateDis Create {get; set;}
        public Discount()
        {
            Save = new ModifyDis();
            Delete = new DeleteDis();
            Create = new CreateDis();
        }
    }
}
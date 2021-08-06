using System;
using System.Collections.Generic;
namespace BLRecords
{
    public class Order
    {
        public DateTimeOffset? OrderDate { get; set; }

        public bool Validate()
        {
            var isValid = false;

            if(OrderDate != null) isValid = true;

            return isValid;
        }
        
        public Order Retrive(int orderId)
        {
            return new Order();
        }
        
        public List<Order>  Retrive()
        {
            return new List<Order>();
        }

        public void Save()
        {

        }
        
        
    }
}

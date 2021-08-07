using System;
using System.Collections.Generic;
namespace BLRecords
{
    public class Order
    {
        public Order(): this(0)
        {
            
        }
        public Order(int OrderID)
        {
            OrderId = OrderID;
            OrderItem = new List<OrderItem>();
        }
        public DateTimeOffset? OrderDate { get; set; }
        public int OrderId { get; private set; }
        public int CustomerId { get; set; }
        public int ShippId { get; set; }
        public List<OrderItem> OrderItem { get; set; }
        
        public bool Validate()
        {
            var isValid = false;

            if(OrderDate != null) isValid = true;

            return isValid;
        }
        
        public List<Order>  Retrive()
        {
            return new List<Order>();
        }

    }
}

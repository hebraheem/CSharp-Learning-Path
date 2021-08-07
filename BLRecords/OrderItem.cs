using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLRecords
{
    public class OrderItem
    {
        public int? Quantity { get; set; }
        public decimal? PurchasePrice { get; set; }        

        public bool Validate()
        {
            var isValid = false;

            if(Quantity != null) isValid = true;

            return isValid;
        }
        
        public OrderItem Retrive(int OrderItemId)
        {
            return new OrderItem();
        }
        
        public List<OrderItem>  Retrive()
        {
            return new List<OrderItem>();
        }

        public void Save()
        {

        }
    }
}

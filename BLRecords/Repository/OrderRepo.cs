using System;
namespace BLRecords
{
    public class OrderRepo
    {
        public Order Retrive()
        {
            var order = new Order();
            order.OrderDate = new DateTimeOffset(DateTime.Now.Year, 4, 14, 10, 00,00, new TimeSpan(7, 0,0));

            return order;
        }

        public bool Save()
        {
            return true;
        }
    }
}
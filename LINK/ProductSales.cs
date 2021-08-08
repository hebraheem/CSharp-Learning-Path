using System.Collections.Generic;

namespace LINK
{
    public class ProductSales
    {
        public Product Product { get; set; }
        public IEnumerable<SalesOrderDetail> Sales { get; set; }

    }
}
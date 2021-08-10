using System.Collections.Generic;

namespace LINK
{
    public class SalesProduct
    {
        public int SalesOrderID { get; set; }
        public List<Product> Products { get; set; }
    }
}
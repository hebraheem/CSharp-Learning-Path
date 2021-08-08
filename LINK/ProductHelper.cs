using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LINK
{
    public static class ProductHelper
    {
        public static IEnumerable<Product> ByColor(this IEnumerable<Product> query, string color)
        {
            return query.Where(_product => _product.Color == color);
        }
    }
}
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace LINK
{
    public class ProductIdComparer : EqualityComparer<Product>
    {
        public override bool Equals(Product x, Product y)
        {
            return (x.ProductID == y.ProductID);
        }

        public override int GetHashCode(Product obj)
        {
            return obj.ProductID.GetHashCode();
        }
    }

    public class ProductComparer : EqualityComparer<Product>
    {
        public override bool Equals(Product x, Product y)
        {
            return (x.ProductID == y.ProductID && x.Name == y.Name && x.Color == y.Color && x.ListPrice == y.ListPrice && x.Size == y.Size && x.StandardCost == y.StandardCost);
        }

        public override int GetHashCode(Product obj)
        {
            return obj.ProductID.GetHashCode();
        }
    }
}
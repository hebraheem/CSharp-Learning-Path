using System;
using System.Collections.Generic;
using System.Linq;

namespace LINK
{
    public class SalesSampleModelView
    {
        #region Constructor
        public SalesSampleModelView()
        {
            // Load all Product Data
            Products = ProductRepository.GetAll();
            // Load all Sales Data
            Sales = SalesOrderDetailRepository.GetAll();
        }
        #endregion

        #region Properties
        public bool UseQuerySyntax { get; set; } = true;
        public List<Product> Products { get; set; }
        public List<SalesOrderDetail> Sales { get; set; }
        public string ResultText { get; set; }
        #endregion

        #region ForEach Method
        /// <summary>
        /// ForEach allows you to iterate over a collection to perform assignments within each object.
        /// In this sample, assign the Length of the Name property to a property called NameLength
        /// When using the Query syntax, assign the result to a temporary variable.
        /// </summary>
        public void ForEach()
        {
            if (UseQuerySyntax)
            {
                // Query Syntax

            }
            else
            {
                // Method Syntax

            }

            ResultText = $"Total Products: {Products.Count}";
        }
        #endregion

        #region ForEachCallingMethod Method
        /// <summary>
        /// Iterate over each object in the collection and call a method to set a property
        /// This method passes in each Product object into the SalesForProduct() method
        /// In the SalesForProduct() method, the total sales for each Product is calculated
        /// The total is placed into each Product objects' ResultText property
        /// </summary>
        public void ForEachCallingMethod()
        {
            if (UseQuerySyntax)
            {
                // Query Syntax
                Products = (from _product in Products let tempSales = _product.TotalSales = SalesForProduct(_product) select _product).ToList();

            }
            else
            {
                // Method Syntax
                Products.ForEach(_product => _product.TotalSales = SalesForProduct(_product));

            }

            ResultText = $"Total Products: {Products.Count}";
        }

        /// <summary>
        /// Helper method called by LINQ to sum sales for a product
        /// </summary>
        /// <param name="prod">A product</param>
        /// <returns>Total Sales for Product</returns>
        private decimal SalesForProduct(Product prod)
        {
            return Sales.Where(sale => sale.ProductID == prod.ProductID)
                        .Sum(sale => sale.LineTotal);
        }
        #endregion

        #region Take Method
        /// <summary>
        /// Use Take() to select a specified number of items from the beginning of a collection
        /// </summary>
        public void Take()
        {
            if (UseQuerySyntax)
            {
                // Query Syntax
                Products = (from _product in Products orderby _product.Name select _product).Take(5).ToList();

            }
            else
            {
                // Method Syntax
                Products = Products.OrderBy(_product => _product.Name).Take(5).ToList();

            }

            ResultText = $"Total Products: {Products.Count}";
        }
        #endregion

        #region TakeWhile Method
        /// <summary>
        /// Use TakeWhile() to select a specified number of items from the beginning of a collection based on a true condition
        /// </summary>
        public void TakeWhile()
        {
            if (UseQuerySyntax)
            {
                // Query Syntax
                Products = (from _product in Products orderby _product.Name select _product).TakeWhile(_product => _product.Name.Contains("B")).ToList();

            }
            else
            {
                // Method Syntax
                Products = Products.OrderBy(_product => _product.Name).TakeWhile(_product => _product.Name.Contains("A")).ToList();

            }

            ResultText = $"Total Products: {Products.Count}";
        }
        #endregion

        #region Skip Method
        /// <summary>
        /// Use Skip() to move past a specified number of items from the beginning of a collection
        /// </summary>
        public void Skip()
        {
            if (UseQuerySyntax)
            {
                // Query Syntax
                Products = (from _product in Products orderby _product.Name select _product).Skip(20).ToList();

            }
            else
            {
                // Method Syntax
                Products = Products.OrderBy(_product => _product.Name).Skip(20).ToList();

            }

            ResultText = $"Total Products: {Products.Count}";
        }
        #endregion

        #region SkipWhile Method
        /// <summary>
        /// Use SkipWhile() to move past a specified number of items from the beginning of a collection based on a true condition
        /// </summary>
        public void SkipWhil()
        {
            if (UseQuerySyntax)
            {
                // Query Syntax
                Products = (from _product in Products orderby _product.Name select _product).SkipWhile(_product => _product.Name.Contains("A")).ToList();

            }
            else
            {
                // Method Syntax
                Products = Products.OrderBy(_product => _product.Name).SkipWhile(_product => _product.Name.Contains("A")).ToList();

            }

            ResultText = $"Total Products: {Products.Count}";
        }
        #endregion

        #region Distinct
        /// <summary>
        /// The Distinct() operator finds all unique values within a collection
        /// In this sample you put distinct product colors into another collection using LINQ
        /// </summary>
        public void Distinct()
        {
            List<string> colors = new List<string>();

            if (UseQuerySyntax)
            {
                // Query Syntax
                colors = (from _product in Products select _product.Color).Distinct().ToList();

            }
            else
            {
                // Method Syntax
                colors = Products.Select(_product => _product.Color).Distinct().ToList();

            }

            // Build string of Distinct Colors
            foreach (var color in colors)
            {
                Console.WriteLine($"Color: {color}");
            }
            Console.WriteLine($"Total Colors: {colors.Count}");

            // Clear products
            Products.Clear();
        }
        #endregion
    }
}

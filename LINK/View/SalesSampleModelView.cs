using System.Drawing;
using System.Text;
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
        public void SkipWhile()
        {
            if (UseQuerySyntax)
            {
                // Query Syntax
                Products = (from _product in Products orderby _product.Name select _product).SkipWhile(_product => _product.Name.ToLower().Contains("l")).ToList();
            }
            else
            {
                // Method Syntax
                Products = Products.OrderBy(_product => _product.Name).SkipWhile(_product => _product.Name.ToLower().Contains("l")).ToList();
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

        public void All()
        {
            bool value = false;
            string search = " ";

            if (UseQuerySyntax)
            {
                //query syntax
                value = (from _product in Products select _product).All(_product => _product.Name.Contains(search));
            }
            else
            {
                //method syntax
                value = Products.All(_product => _product.Name.Contains(search));
            }
            Products.Clear();
            ResultText = $"Do all Name properties contain a {search} {value}";
        }

        public void Any()
        {
            bool value = false;
            string search = "z";

            if (UseQuerySyntax)
            {
                //query syntax
                value = (from _product in Products select _product).Any(_product => _product.Name.Contains(search));
            }
            else
            {
                //method syntax
                value = Products.Any(_product => _product.Name.Contains(search));
            }
            Products.Clear();
            ResultText = $"Do all Name properties contain a {search} {value}";
        }

        public void comparer()
        {
            int Id = 744;
            bool value = false;
            ProductIdComparer pc = new ProductIdComparer();
            Product _productToCompare = new Product { ProductID = Id };

            if (UseQuerySyntax)
            {
                //query syntax
                value = (from _product in Products select _product).Contains(_productToCompare, pc);
            }
            else
            {
                value = Products.Contains(_productToCompare, pc);
            }
            Products.Clear();
            ResultText = $"{value}";
        }

        public void SequeceEqual()
        {
            ProductComparer pc = new ProductComparer();
            var value = false;
            List<Product> _list1 = ProductRepository.GetAll();
            List<Product> _list2 = ProductRepository.GetAll();
            _list1.RemoveAt(0);

            if (UseQuerySyntax)
            {
                //query syntax
                value = (from _product in _list1 select _product).SequenceEqual(_list2, pc);
            }
            else
            {
                value = _list1.SequenceEqual(_list2, pc);
            }
            Products.Clear();
            ResultText = $"{value}";
        }

        public void Except()
        {
            ProductComparer pc = new ProductComparer();
            List<Product> _list1 = ProductRepository.GetAll();
            List<Product> _list2 = ProductRepository.GetAll();
            _list1.RemoveAll(_product => _product.Color == "Black");
            _list2.RemoveAll(_product => _product.ListPrice < 100);

            if (UseQuerySyntax)
            {
                //query syntax
                Products = (from _product in _list1 select _product).Except(_list2, pc).ToList();
            }
            else
            {
                Products = _list1.Except(_list2, pc).ToList();
            }
            ResultText = $"Total product: {Products.Count}";
        }

        public void Intersect()
        {
            ProductComparer pc = new ProductComparer();
            List<Product> _list1 = ProductRepository.GetAll();
            List<Product> _list2 = ProductRepository.GetAll();
            _list1.RemoveAll(_product => _product.Color == "Black");
            _list2.RemoveAll(_product => _product.ListPrice < 100);

            if (UseQuerySyntax)
            {
                //query syntax
                Products = (from _product in _list1 select _product).Intersect(_list2, pc).ToList();
            }
            else
            {
                Products = _list1.Intersect(_list2, pc).ToList();
            }
            ResultText = $"Total product: {Products.Count}";
        }

        public void Union()
        {
            ProductComparer pc = new ProductComparer();
            List<Product> _list1 = ProductRepository.GetAll();
            List<Product> _list2 = ProductRepository.GetAll();

            if (UseQuerySyntax)
            {
                //query syntax
                Products = (from _product in _list1 select _product).Union(_list2, pc).OrderBy(_product => _product.Name).ToList();
            }
            else
            {
                Products = _list1.Union(_list2, pc).OrderBy(_product => _product.Name).ToList();
            }
            ResultText = $"Total product: {Products.Count}";
        }

        public void Concat()
        {
            ProductComparer pc = new ProductComparer();
            List<Product> _list1 = ProductRepository.GetAll();
            List<Product> _list2 = ProductRepository.GetAll();

            if (UseQuerySyntax)
            {
                //query syntax
                Products = (from _product in _list1 select _product).Concat(_list2).OrderBy(_product => _product.Name).ToList();
            }
            else
            {
                Products = _list1.Concat(_list2).OrderBy(_product => _product.Name).ToList();
            }
            ResultText = $"Total product: {Products.Count}";
        }

        public void InnerJoint()
        {
            StringBuilder sb = new StringBuilder(2048);
            int count = 0;

            if (UseQuerySyntax)
            {
                var query = (from _product in Products
                             join sale in Sales on _product.ProductID equals sale.ProductID
                             select new
                             {
                                 _product.ProductID,
                                 _product.Name,
                                 _product.StandardCost,
                                 _product.ListPrice,
                                 _product.Size,
                                 sale.OrderQty,
                                 sale.SalesOrderID,
                                 sale.UnitPrice,
                                 sale.LineTotal,
                             });
                foreach (var _item in query)
                {
                    count++;
                    sb.Append($"Sales Order: {_item.SalesOrderID}");
                    sb.AppendLine($"  ProductId: {_item.ProductID}");
                    sb.AppendLine($"  Product Name: {_item.Name}");
                    sb.AppendLine($"  Size: {_item.Size}");
                    sb.AppendLine($"  Price: {_item.UnitPrice}");
                    sb.AppendLine($"  Cost: {_item.StandardCost}");
                    sb.AppendLine($"  Order Qty: {_item.OrderQty}");
                    sb.AppendLine($"  Total: {_item.LineTotal}");
                }
            }
            else
            {
                var query = Products.Join(Sales, _product => _product.ProductID, sale => sale.ProductID, (_product, sale) => new
                {
                    _product.ProductID,
                    _product.Name,
                    _product.StandardCost,
                    _product.ListPrice,
                    _product.Size,
                    sale.OrderQty,
                    sale.SalesOrderID,
                    sale.UnitPrice,
                    sale.LineTotal,
                });
                foreach (var _item in query)
                {
                    count++;
                    sb.Append($"Sales Order: {_item.SalesOrderID}");
                    sb.AppendLine($"  ProductId: {_item.ProductID}");
                    sb.AppendLine($"  Product Name: {_item.Name}");
                    sb.AppendLine($"  Size: {_item.Size}");
                    sb.AppendLine($"  Price: {_item.UnitPrice}");
                    sb.AppendLine($"  Cost: {_item.StandardCost}");
                    sb.AppendLine($"  Order Qty: {_item.OrderQty}");
                    sb.AppendLine($"  Total: {_item.LineTotal}");
                }
            }
            ResultText = sb.ToString() + Environment.NewLine + "Total Sales: " + count.ToString();
        }

        public void GroupedJoint()
        {
            StringBuilder sb = new StringBuilder(2048);
            IEnumerable<ProductSales> grouped;

            if (UseQuerySyntax)
            {
                grouped = (from _product in Products
                           join _sale in Sales on _product.ProductID equals _sale.ProductID into _sales
                           select new ProductSales
                           {
                               Product = _product,
                               Sales = _sales
                           });
            }
            else
            {
                grouped = Products.GroupJoin(Sales, _product => _product.ProductID, _sale => _sale.ProductID, (_product, _sales) => new ProductSales
                {
                    Product = _product,
                    Sales = _sales
                });
            }
        }

        public void GroupBy()
        {
            StringBuilder sb = new StringBuilder(2480);
            IEnumerable<IGrouping<string, Product>> sizeGrouped;

            if (UseQuerySyntax)
            {
                //query syntax
                sizeGrouped = (from _product in Products orderby _product.Size group _product by _product.Size);
            }
            else
            {
                //method syntax
                sizeGrouped = Products.OrderBy(_product => _product.Size).GroupBy(_product => _product.Size);
            }
            //Loop through each size
            foreach (var group in sizeGrouped)
            {
                //The value in the Key property is
                //what ever data you grouped upon
                sb.AppendLine($"Size: {group.Key} Count: {group.Count()}");

                //loop through the products in each size
                foreach (var _product in group)
                {
                    sb.Append($" ProductId: {_product.ProductID}");
                    sb.Append($" Name: {_product.Name}");
                    sb.AppendLine($" Color: {_product.Color}");
                }
            }
            Products.Clear();
            ResultText = sb.ToString();
        }

        public void GropByIntoSelect()
        {
            StringBuilder sb = new StringBuilder(2480);
            IEnumerable<IGrouping<string, Product>> sizeGrouped;

            if (UseQuerySyntax)
            {
                //query syntax
                sizeGrouped = (from _product in Products orderby _product.Size group _product by _product.Size into _sizes select _sizes);
            }
            else
            {
                //method syntax
                sizeGrouped = Products.OrderBy(_product => _product.Size).GroupBy(_product => _product.Size);
            }
            //Loop through each size
            foreach (var group in sizeGrouped)
            {
                //The value in the Key property is
                //what ever data you grouped upon
                sb.AppendLine($"Size: {group.Key} Count: {group.Count()}");

                //loop through the products in each size
                foreach (var _product in group)
                {
                    sb.Append($" ProductId: {_product.ProductID}");
                    sb.Append($" Name: {_product.Name}");
                    sb.AppendLine($" Color: {_product.Color}");
                }
            }
            Products.Clear();
            ResultText = sb.ToString();
        }

        public void GropByOrderByKey()
        {
            StringBuilder sb = new StringBuilder(2480);
            IEnumerable<IGrouping<string, Product>> sizeGrouped;

            if (UseQuerySyntax)
            {
                //query syntax
                sizeGrouped = (from _product in Products group _product by _product.Size into _sizes orderby _sizes.Key select _sizes);
            }
            else
            {
                //method syntax
                sizeGrouped = Products.GroupBy(_product => _product.Size).OrderBy(_sizes => _sizes.Key).Select(_sizes => _sizes);
            }
            //Loop through each size
            foreach (var group in sizeGrouped)
            {
                //The value in the Key property is
                //what ever data you grouped upon
                sb.AppendLine($"Size: {group.Key} Count: {group.Count()}");

                //loop through the products in each size
                foreach (var _product in group)
                {
                    sb.Append($" ProductId: {_product.ProductID}");
                    sb.Append($" Name: {_product.Name}");
                    sb.AppendLine($" Color: {_product.Color}");
                }
            }
            Products.Clear();
            ResultText = sb.ToString();
        }

        public void GropByWhere()
        {
            StringBuilder sb = new StringBuilder(2480);
            IEnumerable<IGrouping<string, Product>> sizeGrouped;

            if (UseQuerySyntax)
            {
                //query syntax
                sizeGrouped = (from _product in Products group _product by _product.Size into _sizes orderby _sizes.Key where _sizes.Count() > 2 select _sizes);
            }
            else
            {
                //method syntax
                sizeGrouped = Products.GroupBy(_product => _product.Size).OrderBy(_sizes => _sizes.Key).Where(_sizes => _sizes.Count() > 2).Select(_sizes => _sizes);
            }
            //Loop through each size
            foreach (var group in sizeGrouped)
            {
                //The value in the Key property is
                //what ever data you grouped upon
                sb.AppendLine($"Size: {group.Key} Count: {group.Count()}");

                //loop through the products in each size
                foreach (var _product in group)
                {
                    sb.Append($" ProductId: {_product.ProductID}");
                    sb.Append($" Name: {_product.Name}");
                    sb.AppendLine($" Color: {_product.Color}");
                }
            }
            Products.Clear();
            ResultText = sb.ToString();
        }

        public void GroupSubQuery()
        {
            StringBuilder sb = new StringBuilder(2480);
            IEnumerable<SalesProduct> salesGroup;

            //get all product
            if (UseQuerySyntax)
            {
                salesGroup = (from _sale in Sales
                              group _sale by _sale.SalesOrderID into _sales
                              select new SalesProduct
                              {
                                  SalesOrderID = _sales.Key,
                                  Products = (from _product in Products join _sale in Sales on _product.ProductID equals _sale.ProductID where _sale.SalesOrderID == _sales.Key select _product).ToList()
                              });
            }
            else
            {
                //method syntax
                salesGroup = Sales.GroupBy(_sale => _sale.SalesOrderID).Select(_sale => new SalesProduct
                {
                    SalesOrderID = _sale.Key,
                    Products = Products.Join(_sale, _product => _product.ProductID, _sale => _sale.ProductID, (_product, _sale) => _product).ToList()
                });

            }

            foreach (var group in salesGroup)
            {
                //The value in the Key property is
                //what ever data you grouped upon
                sb.AppendLine($"SalesId: {group.SalesOrderID}");

                //loop through the products in each size
                foreach (var _sales in group.Products)
                {
                    sb.Append($" ProductId: {_sales.ProductID}");
                    sb.Append($" Name: {_sales.Name}");
                    sb.AppendLine($" Color: {_sales.Color}");
                }
            }
            Products.Clear();
            ResultText = sb.ToString();
        }
        public void Count()
        {
            int value;

            if (UseQuerySyntax)
            {
                //query syntax
                value = (from _product in Products select _product).Count();
            }
            else
            {
                value = Products.Count();
            }
            Products.Clear();
            ResultText = $"Total Product in Products: {value}";
        }

        public void CountFilter()
        {
            int value;
            string search = "Red";

            if (UseQuerySyntax)
            {
                //query syntax
                value = (from _product in Products select _product).Count(_product => _product.Color == search);
            }
            else
            {
                value = Products.Count(_product => _product.Color == search);
            }
            Products.Clear();
            ResultText = $"Total Product in Products: {value}";
        }

        public void Minimum()
        {
            decimal? value;

            if (UseQuerySyntax)
            {
                //query syntax
                value = (from _product in Products select _product.ListPrice).Min();
            }
            else
            {
                value = Products.Min(_product => _product.ListPrice);
            }
            Products.Clear();
            ResultText = $"Minimum in Products: {value}";
        }

        public void Maximum()
        {
            decimal? value;

            if (UseQuerySyntax)
            {
                //query syntax
                value = (from _product in Products select _product.ListPrice).Max();
            }
            else
            {
                value = Products.Max(_product => _product.ListPrice);
            }
            Products.Clear();
            ResultText = $"Minimum in Products: {value}";
        }


        public void Average()
        {
            decimal? value;

            if (UseQuerySyntax)
            {
                //query syntax
                value = (from _product in Products select _product.ListPrice).Average();
            }
            else
            {
                value = Products.Average(_product => _product.ListPrice);
            }
            Products.Clear();
            ResultText = $"Minimum in Products: {value}";
        }

        public void Sum()
        {
            decimal? value;

            if (UseQuerySyntax)
            {
                //query syntax
                value = (from _product in Products select _product.ListPrice).Sum();
            }
            else
            {
                value = Products.Sum(_product => _product.ListPrice);
            }
            Products.Clear();
            ResultText = $"Minimum in Products: {value}";
        }

        public void AggregateSum()
        {
            decimal? value = 0;

            if (UseQuerySyntax)
            {
                value = (from _product in Products select _product).Aggregate(0M, (Sum, _product) => Sum += _product.ListPrice);
            }
            else
            {
                value = Products.Aggregate(0M, (sum, _product) => sum += _product.ListPrice);
            }
            Products.Clear();
            ResultText = $"Total Product in Products: {value}";
        }

        public void AggregateGroup()
        {
            StringBuilder sb = new StringBuilder();

            if (UseQuerySyntax)
            {
                var stats = (from _product in Products
                             group _product by _product.Size into sizeGroup
                             where sizeGroup.Count() > 20
                             select new
                             {
                                 Size = sizeGroup.Key,
                                 TotalProducts = sizeGroup.Count(),
                                 max = sizeGroup.Max(_product => _product.ListPrice),
                                 min = sizeGroup.Min(_product => _product.ListPrice),
                                 Average = sizeGroup.Average(_product => _product.ListPrice)
                             } into result
                             orderby result.Size
                             select result);

                //Loop through each size
                foreach (var group in stats)
                {
                    sb.AppendLine($"Size: {group.Size} Count: {group.TotalProducts}");
                    sb.AppendLine($"Minimum: {group.min}");
                    sb.AppendLine($"Maximum: {group.max}");
                    sb.AppendLine($"Average: {group.Average}");
                }
            }
            else
            {
                var stats = Products.GroupBy(_product => _product.Size).Where(_product => _product.Count() > 20).Select(_product => new
                {
                    Size = _product.Key,
                    TotalProducts = _product.Count(),
                    max = _product.Max(_product => _product.ListPrice),
                    min = _product.Min(_product => _product.ListPrice),
                    Average = _product.Average(_product => _product.ListPrice)
                }).OrderBy(_product => _product.Size).Select(_result => _result);


                //Loop through each size
                foreach (var group in stats)
                {
                    sb.AppendLine($"Size: {group.Size} Count: {group.TotalProducts}");
                    sb.AppendLine($"Minimum: {group.min}");
                    sb.AppendLine($"Maximum: {group.max}");
                    sb.AppendLine($"Average: {group.Average}");
                }
            }
            ResultText = sb.ToString();
        }
        #endregion
    }
}

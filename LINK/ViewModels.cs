using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINK
{
    public class SamplesViewModel
    {
        #region Constructor
        public SamplesViewModel()
        {
            // Load all Product Data
            Products = ProductRepository.GetAll();
        }
        #endregion

        #region Properties
        public bool UseQuerySyntax { get; set; }
        public List<Product> Products { get; set; }
        public string ResultText { get; set; }
        #endregion

        #region GetAllLooping
        /// <summary>
        /// Put all products into a collection via looping, no LINQ
        /// </summary>
        public void GetAllLooping()
        {
            List<Product> list = new List<Product>();
            foreach (var product in Products)
            {
                list.Add(product);
            }

            ResultText = $"Total Products: {list.Count}";
        }
        #endregion

        #region GetAll
        /// <summary>
        /// Put all products into a collection using LINQ
        /// </summary>
        public Product GetAll()
        {
            List<Product> list = new List<Product>();
            Product _product = new Product();
            if (UseQuerySyntax)
            {
                // Query Syntax
                list = (from product in Products select product).ToList();
                foreach (var prod in list)
                {
                    _product = prod;
                }
            }
            else
            {
                // Method Syntax
                list = Products.Select(product => product).ToList();
                foreach (var prod in list)
                {
                    _product = prod;
                }

            }

            Console.WriteLine($"Total Products: {list.Count}");
            return _product;
        }
        #endregion

        #region GetSingleColumn
        /// <summary>
        /// Select a single column
        /// </summary>
        public void GetSingleColumn()
        {
            StringBuilder sb = new StringBuilder(1024);
            List<string> list = new List<string>();

            if (UseQuerySyntax)
            {
                // Query Syntax
                list.AddRange(from _product in Products select _product.Name);
            }
            else
            {
                // Method Syntax
                list.AddRange(Products.Select(_product => _product.Name));
            }

            foreach (string name in list)
            {
                sb.AppendLine(name);
            }

            Products.Clear();
            ResultText = $"Total Products: {list.Count}" + Environment.NewLine + sb.ToString();
        }
        #endregion

        #region GetSpecificColumns
        /// <summary>
        /// Select a few specific properties from products and create new Product objects
        /// </summary>
        public void GetSpecificColumns()
        {
            if (UseQuerySyntax)
            {
                // Query Syntax
                Products = (from _product in Products
                            select new Product
                            {
                                ProductID = _product.ProductID,
                                Name = _product.Name,
                                Size = _product.Size
                            }).ToList();

            }
            else
            {
                // Method Syntax
                Products = Products.Select(_product => new Product
                {
                    ProductID = _product.ProductID,
                    Name = _product.Name,
                    Size = _product.Size
                }).ToList();

            }

            ResultText = $"Total Products: {Products.Count}";
        }
        #endregion

        #region AnonymousClass
        /// <summary>
        /// Create an anonymous class from selected product properties
        /// </summary>
        public void AnonymousClass()
        {
            StringBuilder sb = new StringBuilder(2048);

            if (UseQuerySyntax)
            {
                // Query Syntax

                var _products = (from product in Products
                                 select new
                                 {
                                     Identifier = product.ProductID,
                                     ProductName = product.Name,
                                     ProductSize = product.Size
                                 });

                // Loop through anonymous class
                foreach (var product in _products)
                {
                    sb.AppendLine($"Product ID: {product.Identifier}");
                    sb.AppendLine($"   Product Name: {product.ProductName}");
                    sb.AppendLine($"   Product Size: {product.ProductSize}");
                }
            }
            else
            {
                // Method Syntax

                var _products = Products.Select(product => new
                {
                    Identifier = product.ProductID,
                    ProductName = product.Name,
                    ProductSize = product.Size
                });

                // Loop through anonymous class
                foreach (var product in _products)
                {
                    sb.AppendLine($"Product ID: {product.Identifier}");
                    sb.AppendLine($"   Product Name: {product.ProductName}");
                    sb.AppendLine($"   Product Size: {product.ProductSize}");
                }
            }

            ResultText = sb.ToString();
            Products.Clear();
        }
        #endregion

        #region OrderBy
        /// <summary>
        /// Order products by Name
        /// </summary>
        public void OrderBy()
        {
            if (UseQuerySyntax)
            {
                // Query Syntax
                Products = (from _product in Products orderby _product.Name select _product).ToList();

            }
            else
            {
                // Method Syntax
                Products = Products.OrderBy(_product => _product.Name).ToList();

            }

            ResultText = $"Total Products: {Products.Count}";
        }
        #endregion

        #region OrderByDescending Method
        /// <summary>
        /// Order products by name in descending order
        /// </summary>
        public void OrderByDescending()
        {
            if (UseQuerySyntax)
            {
                // Query Syntax
                Products = (from _product in Products orderby _product.Name descending select _product).ToList();

            }
            else
            {
                // Method Syntax
                Products = Products.OrderByDescending(_product => _product.Name).ToList();

            }

            ResultText = $"Total Products: {Products.Count}";
        }
        #endregion

        #region OrderByTwoFields Method
        /// <summary>
        /// Order products by Color descending, then Name
        /// </summary>
        public void OrderByTwoFields()
        {
            if (UseQuerySyntax)
            {
                // Query Syntax
                Products = (from _product in Products orderby _product.Color descending, _product.Name select _product).ToList();

            }
            else
            {
                // Method Syntax
                Products = Products.OrderByDescending(_product => _product.Color).ThenBy(_product => _product.Name).ToList();

            }

            ResultText = $"Total Products: {Products.Count}";
        }

        public void filterByName()
        {
            string search = "L";

            if (UseQuerySyntax)
            {
                //query syntax
                Products = (from _product in Products where _product.Name.Contains(search) select _product).ToList();
            }
            else
            {
                //method syntax
                Products = Products.Where(_product => _product.Name.Contains(search)).ToList();
            }

            ResultText = $"Total Products: {Products.Count}";
        }

        public void filteByTwoFields()
        {
            string search = "ML";
            int cost = 200;

            if (UseQuerySyntax)
            {
                //query syntax
                Products = (from _product in Products where _product.Name.Contains(search) && _product.StandardCost > cost select _product).ToList();
            }
            else
            {
                //method syntax
                Products = Products.Where(_product => _product.Name.Contains(search) && _product.StandardCost > cost).ToList();
            }

            ResultText = $"Total Products: {Products.Count}";
        }

        public void ByColorCustom()
        {
            string color = "Red";

            if (UseQuerySyntax)
            {
                //query syntax
                Products = (from _product in Products select _product).ByColor(color).ToList();
            }
            else
            {
                //method syntax
                Products = Products.ByColor(color).ToList();
            }
            ResultText = $"Total Products: {Products.Count}";
        }

        public void singleItemFirst()
        {
            string search = "Red";
            Product value;

            try
            {
                if (UseQuerySyntax)
                {
                    //query sytanx
                    value = (from _product in Products select _product).First(_product => _product.Color == search);
                }
                else
                {
                    //method syntax
                    value = Products.First(_product => _product.Color == search);
                }
                Products.Clear();
                ResultText = $"Found: {value}";
            }
            catch
            {
                // TODO
                Products.Clear();
                ResultText = $"Not Found";
            }
        }

        public void singleItemFirstOrDefault()
        {
            string search = "Redd";
            Product value;


            if (UseQuerySyntax)
            {
                //query sytanx
                value = (from _product in Products select _product).FirstOrDefault(_product => _product.Color == search);
            }
            else
            {
                //method syntax
                value = Products.FirstOrDefault(_product => _product.Color == search);
            }
            Products.Clear();
            if (value != null)
            {
                ResultText = $"Found: {value}";
            }
            else
            {
                ResultText = $"Not Found";
            }

        }

        public void singleLast()
        {
            string search = "Blue";
            Product value;

            try
            {
                if (UseQuerySyntax)
                {
                    //query method
                    value = (from _product in Products select _product).Last(_product => _product.Color == search);
                }
                else
                {
                    //method syntax
                    value = Products.Last(_product => _product.Color == search);
                }
                Products.Clear();
                ResultText = $"Found: {value}";
            }
            catch
            {
                // TODO
                Products.Clear();
                ResultText = $"Not Found";
            }
        }

        public void singleLastOrDefault()
        {
            string search = "Bluee";
            Product value;

            if (UseQuerySyntax)
            {
                //query method
                value = (from _product in Products select _product).LastOrDefault(_product => _product.Color == search);
            }
            else
            {
                //method syntax
                value = Products.LastOrDefault(_product => _product.Color == search);
            }
            Products.Clear();
            if (value != null)
            {
                ResultText = $"Found: {value}";
            }
            else
            {
                ResultText = $"Not Found";
            }
        }

        public void single()
        {
            int search = 744;
            Product value;

            try
            {
                if (UseQuerySyntax)
                {
                    //query syntax 
                    value = (from _product in Products select _product).Single(_product => _product.ProductID == search);
                }
                else
                {
                    //method syntax
                    value = Products.Single(_product => _product.ProductID == search);
                }
                Products.Clear();
                ResultText = $"Found: {value}";
            }
            catch
            {
                Products.Clear();
                ResultText = $"Not Found";
            }
        }

        public void singleOrDefault(int search)
        {
            Product value;

            if (UseQuerySyntax)
            {
                //query syntax 
                value = (from _product in Products select _product).SingleOrDefault(_product => _product.ProductID == search);
            }
            else
            {
                //method syntax
                value = Products.SingleOrDefault(_product => _product.ProductID == search);
            }
            Products.Clear();
            if (value != null)
            {
                ResultText = $"Found: {value}";
            }
            else
            {
                ResultText = "Not Found";
            }

        }
        #endregion
    }
}

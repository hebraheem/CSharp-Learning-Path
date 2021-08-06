using System.Collections.Generic;
using System;

namespace BLRecords
{
    public class Product
    {
        public Product()
        {

        }
        public Product(int ProductId)
        {
            productId = ProductId;
        }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public Decimal? CurrentPrice { get; set; }
        public int? productId { get; private set; }

        public bool Validate()
        {
            var isValid = false;

            if(productId != null) isValid = true;

            return isValid;
        }
        
        public Product Retrive(int productId)
        {
            return new Product();
        }
        
        public List<Product>  Retrive()
        {
            return new List<Product>();
        }

        public void Save()
        {

        }
        
        
    }
}

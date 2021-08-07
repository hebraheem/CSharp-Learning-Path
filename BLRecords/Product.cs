using System.Collections.Generic;
using System;
using common;

namespace BLRecords
{
    public class Product : EntityBase, ILoggable
    {
        public Product()
        {

        }
        public Product(int ProductId)
        {
            productId = ProductId;
        }
        private string _productName;
        public string ProductName
        {
            get
            {
                return _productName.FormatProductname();
            }
            set => _productName = value;
        }
        public string Description { get; set; }
        public Decimal? CurrentPrice { get; set; }
        public int? productId { get; private set; }
        public string Log() => $"Id: {productId}: \n  Name: {ProductName} \n Description: {Description}";
        public override bool Validate()
        {
            var isValid = false;

            if (productId != null && !string.IsNullOrWhiteSpace(ProductName)) isValid = true;

            return isValid;
        }

        public List<Product> Retrive()
        {
            return new List<Product>();
        }
    }
}

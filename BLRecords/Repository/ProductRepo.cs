using System.Net.Http.Headers;
namespace BLRecords
{
    public class ProductRepo
    {
        public Product Retrive(int productId)
        {
            var product = new Product(productId);

            if (productId == 1)
            {
                product.ProductName = "CSharp Tutorials";
                product.Description = "This is a c# learning path";
                product.CurrentPrice = 34;
            }

            return product;
        }
        
        public bool Save(Product product)
        {
            var success = false;
            
            if(product.isValid)
            {
                if(product.IsNew)
                {
                    //insert product
                }
                if(product.HasChanges)
                {
                    //update store
                }
                success = true;
            }
             else 
            {
                success = false;
            }
       
            
            return success;
        }
    }
}
using System;
using Xunit;
using BLRecords;

namespace Test
{
    public class SaveTest
    {
        [Fact]
        public void ProductSaveTest()
        {
            //Given
            var product = new ProductRepo();
            var savedProduct = new Product(1)
            {
                ProductName = "CSharp Tutorials",
                Description = "This is a c# learning path",
                CurrentPrice = 34,
            };
            //When
            var expected = true;
            var actual = product.Save(savedProduct);

            //Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FailedProductSaveTest()
        {
            //Given
            var product = new ProductRepo();
            var savedProduct = new Product(1)
            {
                Description = "This is a c# learning path",
                CurrentPrice = 34,
            };
            //When
            var expected = false;
            var actual = product.Save(savedProduct);

            //Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ProductWithChangeValueSaveTest()
        {
            //Given
            var product = new ProductRepo();
            var savedProduct = new Product(1)
            {
                ProductName = "CSharp Tutorials 1",
                Description = "This is a c# learning path",
                CurrentPrice = 36,
            };
            //When
            var expected = true;
            var actual = product.Save(savedProduct);

            //Then
            Assert.Equal(expected, actual);
        }
    }
}
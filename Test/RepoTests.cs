using System;
using Xunit;
using BLRecords;

namespace Test
{
    public class CustomerRepoTest
    {
        [Fact]
        public void RetriveCustomerTest()
        {
            //arrange
            var c1 = new CustomerRepository();

            var expected = new Customer(1)
            {
                FirstName = "Hebraheem",
                LastName = "Movic",
                Email = "hebraheem@movic.com"
            };

           //act
            var actual = c1.Retrive(1);

            //assert
            Assert.Equal(expected.FirstName, actual.FirstName);
            Assert.Equal(expected.LastName, actual.LastName);
            Assert.Equal(expected.Email, actual.Email);
            
        } 

        [Fact]
        public void RetriveProductTest()
        {
            //arrange
            var p1 = new ProductRepo();

            var expected = new Product(1)
            {
                ProductName = "CSharp Tutorials",
                Description = "This is a c# learning path"
            };

           //act
            var actual = p1.Retrive(1);

            //assert
            Assert.Equal(expected.ProductName, actual.ProductName);
            Assert.Equal(expected.Description, actual.Description);
            
        } 

        [Fact]
        public void RetriveOrderTest()
        {
            //arrange
            var o1 = new OrderRepo();

            var expected = new Order()
            {
                OrderDate = new DateTimeOffset(DateTime.Now.Year, 4, 14, 10, 00,00, new TimeSpan(7, 0,0))
            };

           //act
            var actual = o1.Retrive();

            //assert
            Assert.Equal(expected.OrderDate, actual.OrderDate);
            
        } 
    }
}
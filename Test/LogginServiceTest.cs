using BLRecords;
using Xunit;

namespace Test
{
    public class LogginServiceTest
    {
        [Fact]
        public void CustomerLoggingTest()
        {
            //Given
            var log = new Customer(2);
            log.FirstName = "Hebraheem";
            log.LastName = "Movic";
            log.Email = "hebraheem@gmail.com";

            //When
            var actual = log.Log();
            var expected = $"Id: {2} \n Name: {"Hebraheem, Movic"} \n Email: {"hebraheem@gmail.com"}";

            //Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ProductLoggingTest()
        {
            //Given
            var log = new Product(2)
            {
                ProductName = "CSharp",
                Description = "A Good course you can leverage on"
            };

            //When
            var actual = log.Log();
            var expected = $"Id: {2}: \n  Name: {"C Sharp"} \n Description: {"A Good course you can leverage on"}";

            //Then
            Assert.Equal(expected, actual);
        }
    }
}
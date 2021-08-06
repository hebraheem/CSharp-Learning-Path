using System;
using Xunit;
using BLRecords;

namespace Test
{
    public class CustomerText
    {
        [Fact]
        public void FullNameValidTest()
        {
            //arrange
            Customer c1 = new Customer()
            {
                FirstName = "Hebraheem",
                LastName = "Movic"
            };

            //act
            var fullName = c1.FullName;
            var expected = "Hebraheem, Movic";

            //assert
            Assert.Equal(fullName, expected);
        } 

        [Fact]
        public void FullNameWithOutFirstNameTest()
        {
            //arrange
            Customer c1 = new Customer()
            {
                LastName = "Movic"
            };

            //act
            var fullName = c1.FullName;
            var expected = "Movic";

            //assert
            Assert.Equal(fullName, expected);
        } 

        [Fact]
        public void ValidateTest()
        {
            //arrange
            Customer c1 = new Customer()
            {
                FirstName = "Hebraheem",
                LastName = "Movic"
            };

            //act
            var actual = c1.Validate();
            var expected = true;

            //assert
            Assert.Equal( expected, actual);
        }  

        [Fact]
        public void InValidTest()
        {
            //arrange
            Customer c1 = new Customer()
            {
                FirstName = " ",
                LastName = " "
            };

            //act
            var actual = c1.Validate();
            var expected = false;

            //assert
            Assert.Equal(expected, actual);
        }   

    }
}

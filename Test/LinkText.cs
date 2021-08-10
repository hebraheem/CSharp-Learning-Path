using LINK;
using Xunit;

namespace Test
{
    public class LinkText
    {

        [Fact]
        public void singleLastOrDefaultReturnNotFound()
        {
            //Given
            SamplesViewModel vm = new SamplesViewModel
            {
                UseQuerySyntax = true
            };

            vm.singleOrDefault(444);

            //When
            var expected = @"Not Found";

            //Then
            Assert.Equal(expected, vm.ResultText);
        }


        [Fact]
        public void TakeTest()
        {
            //Given
            SalesSampleModelView sm = new SalesSampleModelView
            {
                UseQuerySyntax = false
            };
            sm.Take();
            //When
            var expected = "Total Products: 5";
            var actual = sm.ResultText;

            //Then
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TakeWhitTest()
        {
            //Given
            SalesSampleModelView sm = new SalesSampleModelView
            {
                UseQuerySyntax = false
            };
            sm.TakeWhile();
            //When
            var expected = "Total Products: 1";
            var actual = sm.ResultText;

            //Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SkipTest()
        {
            //Given
            SalesSampleModelView sm = new SalesSampleModelView
            {
                UseQuerySyntax = false
            };
            sm.Skip();
            //When
            var expected = "Total Products: 20";
            var actual = sm.ResultText;

            //Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SkipWhileTest()
        {
            //Given
            SalesSampleModelView sm = new SalesSampleModelView
            {
                UseQuerySyntax = false
            };
            sm.SkipWhile();
            //When
            var expected = "Total Products: 4";
            var actual = sm.ResultText;

            //Then
            Assert.Equal(expected, actual);
        }
    }
}

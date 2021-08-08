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
    }
}

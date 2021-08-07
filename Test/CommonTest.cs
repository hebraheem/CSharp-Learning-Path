using Xunit;
using common;

namespace Test
{
    public class CommonTest
    {
        [Fact]
        public void ReturnNameWithSpace()
        {
            //Given

            //When
            var expected = "Hebraheem Movic";
            var actual = StringSpacing.FormatProductname("HebraheemMovic");

            //Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NameWithSpaceTest()
        {
            //Given

            //When
            var expected = "Hebraheem Movic";
            var actual = StringSpacing.FormatProductname("Hebraheem Movic");

            //Then
            Assert.Equal(expected, actual);
        }
    }
}
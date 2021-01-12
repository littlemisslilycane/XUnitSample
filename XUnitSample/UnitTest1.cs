using System;
using Xunit;

namespace XUnitSample
{
    public class UnitTest1
    {
        [Fact]
        public void Should_be_equal()
        {
            var expectedValue = 2;
            var actualValue = 2;
            Assert.Equal(expectedValue, actualValue);
        }
    }
}

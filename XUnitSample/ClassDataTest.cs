using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitSample
{
    public class ClassDataTest
    {
        public class TheoryDataTest : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {

                yield return new object[] { 1, 2, false };
                yield return new object[] { 2, 2, true };
                yield return new object[] { 3, 3, true };

            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        public class TypedDataTest : TheoryData<int, int, bool>
        {
            public TypedDataTest()
            {
                Add(102, 104, false);
            }
        }

        [Theory]
        [ClassData(typeof(TheoryDataTest))]
        [ClassData(typeof(TypedDataTest))]
        public void Should_be_equal(int value1, int value2, bool shouldBeEqual)
        {
            if (shouldBeEqual)
            {
                Assert.Equal(value1, value2);
            }
            else
            {
                Assert.NotEqual(value1, value2);
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitSample
{
    public class MemberDataTest
    {
        public static IEnumerable<object[]> Data => new[]
        {
            new object[]{1,2,false },
            new object[]{2,2,true},
            new object[]{3,3,true}
        };

        public static TheoryData<int, int, bool> TypedData => new TheoryData<int, int, bool>
        {
            {3,2,false },
            {2,3,false },
            {5,5,true }
        };

        public class ExternalData
        {
            public static IEnumerable<object[]> GetData(int start) => new[]

                {
                    new object[]{start, start, true},
                    new object[]{start, start+1, false},
                    new object[]{start+1, start+1,true}
                };

            public static TheoryData<int, int, bool> TypedData = new TheoryData<int, int, bool>
            {
                {6,7,false },
                {4,15,false },
                {7,7,true }
            };

        }
        [Theory]
        [MemberData(nameof(Data))]
        [MemberData(nameof(TypedData))]
        [MemberData(nameof(ExternalData.GetData),10, MemberType =typeof(ExternalData))]
        [MemberData(nameof(ExternalData.TypedData),MemberType =typeof(ExternalData))]
        public void Should_be_equal(int value1, int value2, bool shoulBeEqual)
        {
            if (shoulBeEqual)
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

using System;
using Xunit;
using Lab1.Model;
using System.Collections.Generic;

namespace LabTest1
{
    public class LinearFunctionTests
    {
        public static IEnumerable<object?[]> GetData()
        {
            yield return new object?[] { 1, 2, 2, 4 };
            yield return new object?[] { 3, 5, 3, 14 };
            yield return new object?[] { 2.1, 2.3, 5, 12.8 };
        }
        [Theory]
        [MemberData(nameof(GetData))]
        public void ComputeTest(double linear, double constValue, double arg, double expectedResult)
        {
            var sut = new LinearFunction(linear, constValue);

            var actual = sut.Compute(arg);

            Assert.Equal(expectedResult, actual, 3);
        }

    }
}

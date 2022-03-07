using System.Collections.Generic;
using Xunit;

namespace Lab1.Model.Tests
{
    public class SumTests
    {
        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { 7, 5, 2, new Sum() };
            yield return new object[] { -11, -7, -4, new Sum() };
            yield return new object[] { 3, 5, -2, new Sum() };
            yield return new object[] { 10, 0, 10, new Sum() };
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void ComputeTest(int expected, int lhs, int rhs, Sum sum)
        {
            var actual = sum.Compute(lhs, rhs);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToStringTest()
        {
            var sum = new Sum();
            var expected = "Sum";

            var actual = sum.ToString();

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> TestData1()
        {
            yield return new object[] { true, new Sum(), new Sum() };
            yield return new object[] { false, new Sum(), new Sub() };
            yield return new object[] { false, new Sum(), new IntDiv() };
            yield return new object[] { false, new Sum(), new Mul() };
            yield return new object[] { false, new Sum(), new DivRemainder() };
        }

        [Theory]
        [MemberData(nameof(TestData1))]
        public void EqualsTest(bool expected, Sum obj1, Operation obj2)
        {
            var actual = obj1.Equals(obj2);

            Assert.Equal(expected, actual);
        }
    }
}
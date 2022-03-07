using System.Collections.Generic;
using Xunit;

namespace Lab1.Model.Tests
{
    public class SubTests
    {
        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { 3, 5, 2, new Sub() };
            yield return new object[] { -3, -7, -4, new Sub() };
            yield return new object[] { 7, 5, -2, new Sub() };
            yield return new object[] { 20, 20, 0, new Sub() };
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void ComputeTest(int expected, int lhs, int rhs, Sub sub)
        {
            var actual = sub.Compute(lhs, rhs);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToStringTest()
        {
            var sub = new Sub();
            var expected = "Sub";

            var actual = sub.ToString();

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> TestData1()
        {
            yield return new object[] { true, new Sub(), new Sub() };
            yield return new object[] { false, new Sub(), new Sum() };
            yield return new object[] { false, new Sub(), new IntDiv() };
            yield return new object[] { false, new Sub(), new Mul() };
            yield return new object[] { false, new Sub(), new DivRemainder() };
        }

        [Theory]
        [MemberData(nameof(TestData1))]
        public void EqualsTest(bool expected, Sub obj1, Operation obj2)
        {
            var actual = obj1.Equals(obj2);

            Assert.Equal(expected, actual);
        }
    }
}
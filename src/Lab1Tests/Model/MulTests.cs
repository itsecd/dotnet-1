using System.Collections.Generic;
using Xunit;

namespace Lab1.Model.Tests
{
    public class MulTests
    {
        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { 10, 5, 2, new Mul() };
            yield return new object[] { 28, -7, -4, new Mul() };
            yield return new object[] { -10, 5, -2, new Mul() };
            yield return new object[] { 0, 20, 0, new Mul() };
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void ComputeTest(int expected, int lhs, int rhs, Mul mul)
        {
            var actual = mul.Compute(lhs, rhs);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToStringTest()
        {
            var mul = new Mul();
            var expected = "Mul";

            var actual = mul.ToString();

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> TestData1()
        {
            yield return new object[] { true, new Mul(), new Mul() };
            yield return new object[] { false, new Mul(), new Sum() };
            yield return new object[] { false, new Mul(), new IntDiv() };
            yield return new object[] { false, new Mul(), new Sub() };
            yield return new object[] { false, new Mul(), new DivRemainder() };
        }

        [Theory]
        [MemberData(nameof(TestData1))]
        public void EqualsTest(bool expected, Mul obj1, Operation obj2)
        {
            var actual = obj1.Equals(obj2);

            Assert.Equal(expected, actual);
        }
    }
}
using System.Collections.Generic;
using Xunit;

namespace Lab1.Model.Tests
{
    public class MulTests
    {
        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { 10, 5, 2 };
            yield return new object[] { 28, -7, -4 };
            yield return new object[] { -10, 5, -2 };
            yield return new object[] { 0, 20, 0 };
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void ComputeTest(int expected, int lhs, int rhs)
        {
            var sut = new Mul();

            var actual = sut.Compute(lhs, rhs);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToStringTest()
        {
            var sut = new Mul();
            var expected = "Mul";

            var actual = sut.ToString();

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> TestData1()
        {
            yield return new object[] { true, new Mul() };
            yield return new object[] { false, new Sum() };
            yield return new object[] { false, new IntDiv() };
            yield return new object[] { false, new Sub() };
            yield return new object[] { false, new DivRemainder() };
        }

        [Theory]
        [MemberData(nameof(TestData1))]
        public void EqualsTest(bool expected, Operation obj)
        {
            var sut = new Mul();

            var actual = sut.Equals(obj);

            Assert.Equal(expected, actual);
        }
    }
}
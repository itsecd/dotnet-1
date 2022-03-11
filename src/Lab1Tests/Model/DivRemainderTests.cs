using System.Collections.Generic;
using Xunit;

namespace Lab1.Model.Tests
{
    public class DivRemainderTests
    {

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { 1, 5, 2 };
            yield return new object[] { 3, 7, 4 };
            yield return new object[] { 1, 5, -2 };
            yield return new object[] { 0, 20, 10 };
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void ComputeTest(int expected, int lhs, int rhs)
        {
            var sut = new DivRemainder();

            var actual = sut.Compute(lhs, rhs);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToStringTest()
        {
            var sut = new DivRemainder();
            var expected = "DivRemainder";

            var actual = sut.ToString();

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> TestData1()
        {
            yield return new object[] { true, new DivRemainder() };
            yield return new object[] { false, new Sum() };
            yield return new object[] { false, new IntDiv() };
            yield return new object[] { false, new Sub() };
            yield return new object[] { false, new Mul() };
        }

        [Theory]
        [MemberData(nameof(TestData1))]
        public void EqualsTest(bool expected, Operation obj)
        {
            var sut = new DivRemainder();

            var actual = sut.Equals(obj);

            Assert.Equal(expected, actual);
        }
    }
}
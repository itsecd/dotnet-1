using System.Collections.Generic;
using Xunit;

namespace Lab1.Model.Tests
{
    public class IntDivTests
    {

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { 2, 5, 2 };
            yield return new object[] { 1, 7, 4 };
            yield return new object[] { -2, 5, -2 };
            yield return new object[] { 4, 20, 5 };
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void ComputeTest(int expected, int lhs, int rhs)
        {
            var sut = new IntDiv();

            var actual = div.Compute(lhs, rhs);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToStringTest()
        {
            var sut = new IntDiv();
            var expected = "IntDiv";

            var actual = sut.ToString();

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> TestData1()
        {
            yield return new object[] { true, new IntDiv() };
            yield return new object[] { false, new DivRemainder() };
            yield return new object[] { false, new Sum() };
            yield return new object[] { false, new Sub() };
            yield return new object[] { false, new Mul() };
        }

        [Theory]
        [MemberData(nameof(TestData1))]
        public void EqualsTest(bool expected, Operation obj)
        {
            var sut = new IntDiv();

            var actual = sut.Equals(obj);

            Assert.Equal(expected, actual);
        }
    }
}
using System.Collections.Generic;
using Xunit;

namespace Lab1.Model.Tests
{
    public class IntDivTests
    {

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { 2, 5, 2, new IntDiv() };
            yield return new object[] { 1, 7, 4, new IntDiv() };
            yield return new object[] { -2, 5, -2, new IntDiv() };
            yield return new object[] { 4, 20, 5, new IntDiv() };
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void ComputeTest(int expected, int lhs, int rhs, IntDiv div)
        {
            var actual = div.Compute(lhs, rhs);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToStringTest()
        {
            var div = new IntDiv();
            var expected = "IntDiv";

            var actual = div.ToString();

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> TestData1()
        {
            yield return new object[] { true, new IntDiv(), new IntDiv() };
            yield return new object[] { false, new IntDiv(), new DivRemainder() };
            yield return new object[] { false, new IntDiv(), new Sum() };
            yield return new object[] { false, new IntDiv(), new Sub() };
            yield return new object[] { false, new IntDiv(), new Mul() };
        }

        [Theory]
        [MemberData(nameof(TestData1))]
        public void EqualsTest(bool expected, IntDiv obj1, Operation obj2)
        {
            var actual = obj1.Equals(obj2);

            Assert.Equal(expected, actual);
        }
    }
}
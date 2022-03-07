using System.Collections.Generic;
using Xunit;

namespace Lab1.Model.Tests
{
    public class DivRemainderTests
    {

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { 1, 5, 2, new DivRemainder() };
            yield return new object[] { 3, 7, 4, new DivRemainder() };
            yield return new object[] { 1, 5, -2, new DivRemainder() };
            yield return new object[] { 0, 20, 10, new DivRemainder() };
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void ComputeTest(int expected, int lhs, int rhs, DivRemainder DivRem)
        { 
            var actual = DivRem.Compute(lhs, rhs);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToStringTest()
        {
            var DivRem= new DivRemainder();
            var expected = "DivRemainder";

            var actual = DivRem.ToString();

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> TestData1()
        {
            yield return new object[] { true, new DivRemainder(), new DivRemainder() };
            yield return new object[] { false, new DivRemainder(), new Sum() };
            yield return new object[] { false, new DivRemainder(), new IntDiv() };
            yield return new object[] { false, new DivRemainder(), new Sub() };
            yield return new object[] { false, new DivRemainder(), new Mul() };
        }

        [Theory]
        [MemberData(nameof(TestData1))]
        public void EqualsTest(bool expected, DivRemainder obj1, Operation obj2)
        {
            var actual = obj1.Equals(obj2);

            Assert.Equal(expected, actual);
        }
    }
}
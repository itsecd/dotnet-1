using Xunit;
using Lab1.Model;

namespace Lab1.Model.Tests
{
    public class DivRemainderTests
    {
        [Fact]
        public void ComputeTest()
        {
            var lhs = 5;
            var rhs = 2;
            var obj1 = new DivRemainder();
            var executed = 1;
            var actual = obj1.Compute(lhs, rhs);
            Assert.Equal(executed, actual);
        }

        [Fact]
        public void ToStringTest()
        {
            var obj1 = new DivRemainder();
            var executed = "DivRemainder";
            var actual = obj1.ToString();
            Assert.Equal(executed, actual);
        }

        [Fact]
        public void EqualsTest()
        {
            var obj1 = new DivRemainder();
            var obj2 = new DivRemainder();
            var executed = true;
            var actual = obj1.Equals(obj2);
            Assert.Equal(executed, actual);
        }
    }
}
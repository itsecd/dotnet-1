using Xunit;

namespace Lab1.Model.Tests
{
    public class MulTests
    {
        [Fact]
        public void ComputeTest()
        {
            var lhs = 5;
            var rhs = 10;
            var obj1 = new Mul();
            var executed = 50;
            var actual = obj1.Compute(lhs, rhs);
            Assert.Equal(executed, actual);
        }

        [Fact]
        public void ToStringTest()
        {
            var obj1 = new Mul();
            var executed = "Mul";
            var actual = obj1.ToString();
            Assert.Equal(executed, actual);
        }

        [Fact]
        public void EqualsTest()
        {
            var obj1 = new Mul();
            var obj2 = new Mul();
            var executed = true;
            var actual = obj1.Equals(obj2);
            Assert.Equal(executed, actual);
        }
    }
}
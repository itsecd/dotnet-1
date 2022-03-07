using Xunit;

namespace Lab1.Model.Tests
{
    public class SumTests
    {
        [Fact]
        public void ComputeTest()
        {
            var lhs = 5;
            var rhs = 15;
            var obj1 = new Sum();
            var executed = 20;
            var actual = obj1.Compute(lhs, rhs);
            Assert.Equal(executed, actual);
        }

        [Fact]
        public void ToStringTest()
        {
            var obj1 = new Sum();
            var executed = "Sum";
            var actual = obj1.ToString();
            Assert.Equal(executed, actual);
        }

        [Fact]
        public void EqualsTest()
        {
            var obj1 = new Sum();
            var obj2 = new Sum();
            var executed = true;
            var actual = obj1.Equals(obj2);
            Assert.Equal(executed, actual);
        }
    }
}
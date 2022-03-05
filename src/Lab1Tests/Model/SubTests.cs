using Xunit;
using Lab1.Model;

namespace Lab1.Model.Tests
{
    public class SubTests
    {
        [Fact]
        public void ComputeTests()
        {
            var lhs = 15;
            var rhs = 5;
            var obj1 = new Sub();
            var executed = 10;
            var actual = obj1.Compute(lhs, rhs);
            Assert.Equal(executed, actual);
        }

        [Fact]
        public void ToStringTest()
        {
            var obj1 = new Sub();
            var executed = "Sub";
            var actual = obj1.ToString();
            Assert.Equal(executed, actual);
        }

        [Fact]
        public void EqualsTest()
        {
            var obj1 = new Sub();
            var obj2 = new Sub();
            var executed = true;
            var actual = obj1.Equals(obj2);
            Assert.Equal(executed, actual);
        }
    }
}
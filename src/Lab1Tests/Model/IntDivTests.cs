using Xunit;
using Lab1.Model;

namespace Lab1.Model.Tests
{
    public class IntDivTests
    {
        [Fact]
        public void ComputeTest()
        {
            var lhs = 12;
            var rhs = 3;
            var obj1 = new IntDiv();
            var executed = 4;
            var actual = obj1.Compute(lhs, rhs);
            Assert.Equal(executed, actual);
        }

        [Fact]
        public void ToStringTest()
        {
            var obj1 = new IntDiv();
            var executed = "IntDiv";
            var actual = obj1.ToString();
            Assert.Equal(executed, actual);
        }

        [Fact]
        public void EqualsTest()
        {
            var obj1 = new IntDiv();
            var obj2 = new IntDiv();
            var executed = true;
            var actual = obj1.Equals(obj2);
            Assert.Equal(executed, actual);
        }
    }
}
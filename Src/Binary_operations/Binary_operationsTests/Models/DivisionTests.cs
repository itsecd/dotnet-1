using Xunit;

namespace Binary_operations.Models.Tests
{
    
    public class DivisionTests
    {
        [Fact]
        public void GetResultTest()
        {
            var left = 68;
            var right = 17;
            var obj1 = new Division();
            var executed = 4;
            var actual = obj1.GetResult(left, right);
            Assert.Equal(executed, actual);
        }

        [Fact]
        public void EqualsTest()
        {
            var obj1 = new Division();
            var obj2 = new Division();
            var executed = true;
            var actual = obj1.Equals(obj2);
            Assert.Equal(executed, actual);
        }

        [Fact]
        public void ToStringTest()
        {
            var obj1 = new Division();
            var executed = "test";
            var actual = obj1.ToString();
            Assert.Equal(executed.GetType(), actual.GetType());
        }
    }
}
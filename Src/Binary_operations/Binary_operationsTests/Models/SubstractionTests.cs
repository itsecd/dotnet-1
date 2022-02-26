using Xunit;
namespace Binary_operations.Models.Tests
{
    public class SubstractionTests
    {
        [Fact]
        public void GetResultTest()
        {
            var left = 10;
            var right = 12;
            var obj1 = new Substraction();
            var executed = -2;
            var actual = obj1.GetResult(left, right);
            Assert.Equal(executed, actual);
        }

        [Fact]
        public void EqualsTest()
        {
            var obj1 = new Substraction();
            var obj2 = new Substraction();
            var executed = true;
            var actual = obj1.Equals(obj2);
            Assert.Equal(executed, actual);
        }

        [Fact]
        public void ToStringTest()
        {
            var obj1 = new Substraction();
            var executed = "test";
            var actual = obj1.ToString();
            Assert.Equal(executed.GetType(), actual.GetType());
        }
    }
}
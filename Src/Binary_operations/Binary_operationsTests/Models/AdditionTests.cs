using Xunit;
namespace Binary_operations.Models.Tests
{
    
    public class AdditionTests
    {
        [Fact]
        public void GetResultTest()
        {
            var left = 10;
            var right = 12;
            var obj1 = new Addition();
            var executed = 22;
            var actual = obj1.GetResult(left, right);
            Assert.Equal(executed, actual);
        }

        [Fact]
        public void ToStringTest()
        {
            var obj1 = new Addition();
            var executed = "test";
            var actual = obj1.ToString();
            Assert.Equal(executed.GetType(), actual.GetType());
        }

        [Fact]
        public void EqualsTest()
        {
            var obj1 = new Addition();
            var obj2 = new Addition();
            var executed = true;
            var actual = obj1.Equals(obj2);
            Assert.Equal(executed, actual);
        }
    }
}
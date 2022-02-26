using Xunit;
namespace Binary_operations.Models.Tests
{
    
    public class MultyplicationTests
    {
        [Fact]
        public void GetResultTest()
        {
            var left = 10;
            var right = 2;
            var obj1 = new Multyplication();
            var executed = 20;
            var actual = obj1.GetResult(left, right);
            Assert.Equal(executed, actual);
        }

        [Fact]
        public void EqualsTest()
        {
            var obj1 = new Multyplication();
            var obj2 = new Multyplication();
            var executed = true;
            var actual = obj1.Equals(obj2);
            Assert.Equal(executed, actual);
        }

        [Fact]
        public void ToStringTest()
        {
            var obj1 = new Multyplication();
            var executed = "test";
            var actual = obj1.ToString();
            Assert.Equal(executed.GetType(), actual.GetType());
        }
    }
}
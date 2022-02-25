using Xunit;
namespace Binary_operations.Models.Tests
{
    
    public class AdditionTests
    {
        [Fact]
        public void GetResultTest()
        {
            var obj1 = new Addition(10, 12);
            var executed = 22;
            var actual = obj1.GetResult(obj1.Lhs, obj1.Rhs);
            Assert.Equal(executed, actual);
        }

        [Fact]
        public void ToStringTest()
        {
            var obj1 = new Addition(1, 2);
            var executed = "test";
            var actual = obj1.ToString();
            Assert.Equal(executed.GetType(), actual.GetType());
        }

        [Fact]
        public void EqualsTest()
        {
            var obj1 = new Addition(1, 2);
            var obj2 = new Addition(1, 3);
            var executed = false;
            var actual = obj1.Equals(obj2);
            Assert.Equal(executed, actual);
        }
    }
}
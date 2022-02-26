using Xunit;

namespace Binary_operations.Models.Tests
{
    public class RemainderTests
    {
        [Fact]
        public void GetResultTest()
        {
            int left = 23;
            int right = 4;
            var obj1 = new Remainder();
            var executed = 3;
            var actual = obj1.GetResult(left, right);
            Assert.Equal(executed, actual);
        }

        [Fact]
        public void EqualsTest()
        {
            var obj1 = new Remainder();
            var obj2 = new Remainder();
            var executed = true;
            var actual = obj1.Equals(obj2);
            Assert.Equal(executed, actual);
        }

        [Fact]
        public void ToStringTest()
        {
            var obj1 = new Remainder();
            var executed = "test";
            var actual = obj1.ToString();
            Assert.Equal(executed.GetType(), actual.GetType());
        }
    }
}
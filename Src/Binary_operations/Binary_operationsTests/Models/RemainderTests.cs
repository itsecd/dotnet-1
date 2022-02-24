using Xunit;

namespace Binary_operations.Models.Tests
{
    public class RemainderTests
    {
        [Fact]
        public void GetResultTest()
        {
            var obj1 = new Remainder(10, 3);
            var executed = 1;
            var actual = obj1.GetResult();
            Assert.Equal(executed, actual);
        }

        [Fact]
        public void EqualsTest()
        {
            var obj1 = new Remainder(1, 2);
            var obj2 = new Remainder(1, 2);
            var executed = true;
            var actual = obj1.Equals(obj2);
            Assert.Equal(executed, actual);
        }

        [Fact]
        public void ToStringTest()
        {
            var obj1 = new Remainder(1, 2);
            var executed = "test";
            var actual = obj1.ToString();
            Assert.Equal(executed.GetType(), actual.GetType());
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Binary_operations.Models.Tests
{
    [TestClass()]
    public class RemainderTests
    {
        [TestMethod()]
        public void GetResultTest()
        {
            var obj1 = new Remainder(10, 3);
            var executed = 1;
            var actual = obj1.GetResult();
            Assert.AreEqual(executed, actual);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            var obj1 = new Remainder(1, 2);
            var obj2 = new Remainder(1, 2);
            var executed = true;
            var actual = obj1.Equals(obj2);
            Assert.AreEqual(executed, actual);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            var obj1 = new Remainder(1, 2);
            var executed = "test";
            var actual = obj1.ToString();
            Assert.AreEqual(executed.GetType(), actual.GetType());
        }
    }
}
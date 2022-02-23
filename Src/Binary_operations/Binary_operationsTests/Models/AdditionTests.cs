using Microsoft.VisualStudio.TestTools.UnitTesting;
using Binary_operations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_operations.Models.Tests
{
    [TestClass()]
    public class AdditionTests
    {
        [TestMethod()]
        public void GetResultTest()
        {
            var obj1 = new Addition(10, 12);
            var executed = 22;
            var actual = obj1.GetResult();
            Assert.AreEqual(executed, actual);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            var obj1 = new Addition(1, 2);
            var executed = "test";
            var actual = obj1.ToString();
            Assert.AreEqual(executed.GetType(), actual.GetType());
        }

        [TestMethod()]
        public void EqualsTest()
        {
            var obj1 = new Addition(1, 2);
            var obj2 = new Addition(1, 3);
            var executed = false;
            var actual = obj1.Equals(obj2);
            Assert.AreEqual(executed, actual);
        }
    }
}
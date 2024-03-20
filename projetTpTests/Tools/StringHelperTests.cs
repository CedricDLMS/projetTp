using Microsoft.VisualStudio.TestTools.UnitTesting;
using projetTp.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetTp.Tools.Tests
{
    [TestClass()]
    public class StringHelperTests
    {
        [TestMethod()]
        public void stringCheckTest()
        {
            Assert.IsTrue("qdsdqsd8".stringCheckNotValid());
        }
        [TestMethod()]
        public void stringCheckTest1()
        {
            Assert.IsTrue("897".stringCheckNotValid());
        }
        [TestMethod()]
        public void stringCheckTest2()
        {
            Assert.IsTrue("     ".stringCheckNotValid());
        }
        [TestMethod()]
        public void stringCheckTest4()
        {
            Assert.IsTrue("   89 dsq".stringCheckNotValid());
        }
        [TestMethod()]
        public void stringCheckTest5()
        {
            Assert.IsFalse("MarqueBien".stringCheckNotValid());
        }
        [TestMethod()]
        public void stringCheckTest6()
        {
            Assert.IsFalse("qsdqsEdoqs".stringCheckNotValid());
        }
    }
}
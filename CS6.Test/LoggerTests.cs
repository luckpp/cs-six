using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace CS6.Test
{
    [TestClass]
    public class LoggerTests
    {
        [TestMethod]
        public void Initial_State()
        {
            var logger = new Logger();

            AreEqual(1, logger.Count());
            AreEqual("Logger has been initialized", logger.First());
        }

        [TestMethod]
        public void Extension_Add_Method()
        {
            const string logItem = "Log Item";
            var logger = new Logger { logItem };

            AreEqual(2, logger.Count());
            AreEqual(logItem, logger.Skip(1).First());
        }
    }
}

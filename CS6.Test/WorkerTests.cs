using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace CS6.Test
{
    [TestClass]
    public class WorkerTests
    {
        [TestMethod]
        public void Name_Default()
        {
            using (var logger = new Logger())
            using (var worker = new Worker(logger))
            {
                Assert.AreEqual("Default-Name", worker.Name);
            }
        }

        [TestMethod]
        public void Name_Custom()
        {
            const string customName = "Custom-Name";

            using (var logger = new Logger())
            using (var worker = new Worker(logger, customName))
            {
                Assert.AreEqual(customName, worker.Name);
            }
        }

        [TestMethod]
        public void String_Representation()
        {
            using (var logger = new Logger())
            using (var worker = new Worker(logger, "Name"))
            {
                Assert.AreEqual("Worker: Name", worker.ToString());
            }
        }

        [TestMethod]
        public async Task Execute_Failing_Operation()
        {
            using (var logger = new Logger())
            using (var worker = new Worker(logger))
            {
                await worker.Execute(() => FailingOperation(50));
                Assert.AreEqual($"Error code {50}", await logger.GetLastLogAsync());
            }
        }

        private void FailingOperation(int errorCode)
        {
            throw new WorkerException { Code = errorCode };
        }
    }
}

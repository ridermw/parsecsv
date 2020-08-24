using Microsoft.VisualStudio.TestTools.UnitTesting;
using console;
namespace console.tests
{
    [TestClass]
    public class ConsoleUnitTests
    {
        private readonly Program _program;

        public ConsoleUnitTests()
        {
            _program = new Program();
        }

        [TestMethod]
        public void ProgramWithNoArgs()
        {
            Assert.IsFalse(Program.ValidateArgs(new string[0]));
        }

        [TestMethod]
        public void ProgramWithOneArgs()
        {
            Assert.IsTrue(Program.ValidateArgs(new string[1]));
        }

        [TestMethod]
        public void ProgramWithManyArgs()
        {
            Assert.IsFalse(Program.ValidateArgs(new string[10]));
        }
    }
}

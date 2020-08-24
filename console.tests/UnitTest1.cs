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
            Assert.IsTrue(Program.ValidateArgs(new string[0]) == ErrorCode.NO_ARGS);
        }

        [TestMethod]
        public void ProgramWithOneArgs()
        {
            Assert.IsTrue(Program.ValidateArgs(new string[1]) == ErrorCode.NONE);
        }

        [TestMethod]
        public void ProgramWithManyArgs()
        {
            Assert.IsTrue(Program.ValidateArgs(new string[10]) == ErrorCode.MORE_THAN_ONE_ARGS);
        }
    }
}

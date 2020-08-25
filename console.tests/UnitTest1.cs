using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace console.tests
{
    [TestClass]
    /// <summary>
    /// unit tests for parsecsv
    /// </summary>
    public class ConsoleUnitTests
    {
        [TestMethod]
        public void NoArgs()
        {
            Assert.IsTrue(Program.ValidateArgs(new string[0]) == ErrorCode.NO_ARGS);
        }

        [TestMethod]
        public void InvalidFileName()
        {
            Assert.IsTrue(Program.ValidateArgs(new string[1]) == ErrorCode.FILE_NOT_FOUND);
        }

        [TestMethod]
        public void ManyArgs()
        {
            Assert.IsTrue(Program.ValidateArgs(new string[10]) == ErrorCode.MORE_THAN_ONE_ARGS);
        }

        [TestMethod]
        public void ValidFileName()
        {
            var fileName = new string[1];
            fileName[0] = "../../../valid.csv";
            Assert.IsTrue(Program.ValidateArgs(fileName) == ErrorCode.NONE);
        }

        [TestMethod]
        public void InvalidFileFewerColumns()
        {
            var fileName = new string[1];
            fileName[0] = "../../../invalid_fewer.csv";
            Assert.IsTrue(Program.ValidateArgs(fileName) == ErrorCode.NONE);
        }

        [TestMethod]
        public void InvalidFileMoreColumns()
        {
            var fileName = new string[1];
            fileName[0] = "../../../invalid_more.csv";
            Assert.IsTrue(Program.ValidateArgs(fileName) == ErrorCode.NONE);
        }
        [TestMethod]
        public void ValidFileParsed()
        {
            var fileName = new string[1];
            fileName[0] = "../../../invalid_more.csv";
            Assert.IsTrue(Program.ParseCsv(fileName) == ErrorCode.NONE);
        }

        [TestMethod]
        public void InvalidFileParsedFewerValues()
        {
            var fileName = new string[1];
            fileName[0] = "../../../invalid_fewer.csv";
            Assert.IsTrue(Program.ParseCsv(fileName) == ErrorCode.FEWER_THAN_FIVE);
        }

    }
}

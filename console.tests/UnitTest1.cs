using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

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
        public void ValidFileParsed()
        {
            var fileName = "../../../valid.csv";
            Assert.IsTrue(Program.ParseCsv(fileName) == ErrorCode.NONE);
        }

        [TestMethod]
        public void InvalidFileParsedFewerValues()
        {
            var fileName = "../../../invalid_fewer.csv";
            Assert.IsTrue(Program.ParseCsv(fileName) == ErrorCode.FEWER_THAN_FIVE);
        }

        [TestMethod]
        public void InvalidFileParsedMoreValues()
        {
            //using StringWriter to capture standard output
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                var fileName = "../../../invalid_more.csv";
                Program.ParseCsv(fileName);
                
                Assert.IsTrue(sw.ToString().Contains("WARNING: This line contains more than five values."));
            }            
        }

        [TestMethod]
        public void NonexistingFileParsed()
        {
            //using StringWriter to capture standard output
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                var fileName = "../../../asdf.csv";
                Program.ParseCsv(fileName);
                
                Assert.IsTrue(sw.ToString().Contains("ERROR: There was a problem reading from the file:"));
            }         
        }
    }
}

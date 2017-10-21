using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Arrow.Core;

namespace CompilerTests
{
    [TestClass]
    public class Program
    {
        [TestMethod]
        public void MainParsingTest()
        {
            var compiler = new ArrowCompiler();
            var result = compiler.Run(File.ReadAllText(@".\Test.arrow"));

            Assert.AreEqual(result(), 17);
        }
    }
}

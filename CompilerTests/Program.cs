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

        [TestMethod]
        public void WhiteSpaceTest()
        {
            var compiler = new ArrowCompiler();
            Assert.AreEqual(compiler.Run(@"ret 1+1;")(), 2);
            Assert.AreEqual(compiler.Run(@"ret 1 + 1;")(), 2);
            Assert.AreEqual(compiler.Run(@" ret  1  +  1 ; ")(), 2);
            Assert.AreEqual(compiler.Run(@"var a= 2;ret a+1;")(), 3);
        }

        [TestMethod]
        public void NewLineTest()
        {
            var compiler = new ArrowCompiler();
            Assert.AreEqual(compiler.Run($"ret {Environment.NewLine}1 + 1;")(), 2);
            Assert.AreEqual(compiler.Run($"var {Environment.NewLine}a= 2;{Environment.NewLine}ret 1 + 1;")(), 2);
        }
    }
}

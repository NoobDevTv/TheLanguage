using Arrow.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerTests
{
    [TestClass]
    public class NewLineTests
    {
        ArrowCompiler compiler;

        public NewLineTests()
        {
            compiler = new ArrowCompiler();
        }

        [TestMethod]
        public void NewLineTest0()
        {
            Assert.AreEqual(compiler.RunFunc<int>($"ret {Environment.NewLine}1 + 1;")(), 2);
        }

        [TestMethod]
        public void NewLineTest1()
        {
            Assert.AreEqual(compiler.RunFunc<int>($"var {Environment.NewLine}a= 2;{Environment.NewLine}ret 1 + 1;")(), 2);
        }
    }
}

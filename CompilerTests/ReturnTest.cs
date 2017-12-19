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
    public class ReturnTest
    {
        ArrowCompiler compiler;

        public ReturnTest()
        {
            compiler = new ArrowCompiler();
        }

        [TestMethod]
        public void ReturnWithoutWhiteSpace()
        {
            Assert.AreEqual(compiler.RunFunc<int>(@"ret 1+1;")(), 2);
        }

        [TestMethod]
        public void WhiteSpaceTest1()
        {
            Assert.AreEqual(compiler.RunFunc<int>(@"ret 1 + 1;")(), 2);
        }

        [TestMethod]
        public void WhiteSpaceTest2()
        {
            Assert.AreEqual(compiler.RunFunc<int>(@" ret  1  +  1 ; ")(), 2);
        }

        [TestMethod]
        public void WhiteSpaceTest3()
        {
            Assert.AreEqual(compiler.RunFunc<int>(@" ret  1  +  1 ; ")(), 2);
        }

        [TestMethod]
        public void WhiteSpaceTest4()
        {
            Assert.AreEqual(compiler.RunFunc<int>(@"var a= 2;ret a+1;")(), 3);
        }
    }
}

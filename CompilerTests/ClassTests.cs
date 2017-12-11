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
    public class ClassTests
    {
        private ArrowCompiler compiler;

        public ClassTests()
        {
            compiler = new ArrowCompiler();
        }

        [TestMethod]
        public void EmptyClassTest()
        {
            compiler.GetAssembly("class test;");
        }

        [TestMethod]
        public void EmptyClassInheritanceTest()
        {
            compiler.GetAssembly(
                "class test0;" +
                "class test1 < test0;");
        }

        [TestMethod]
        public void ClassTest()
        {
            compiler.GetAssembly(
                @"class test {

                  }");
        }

        [TestMethod]
        public void ClassInheritanceTest()
        {
            compiler.GetAssembly(
                @"
                class test0;
                class test < test0 {

                  }");
        }
    }
}

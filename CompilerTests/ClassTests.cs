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
        public void MultiEmptyClassTest()
        {
            compiler.GetAssembly("class test0;" +
                "class test1;" +
                "class test2;");
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

        [TestMethod]
        public void TwoClassesTest()
        {
            compiler.GetAssembly(
                @"
                class test {

                  }
                class test0;
                ");
        }

        [TestMethod]
        public void ClassWithMethodsTest()
        {
            compiler.GetAssembly(@"
            class test {
            def Hallo(){}
            def Hallo2(){}
            }");
        }

        [TestMethod]
        public void ClassInherienceWithMethodsTest()
        {
            compiler.GetAssembly(@"
            class test0 {
                def Tango(){}
            }

            class test < test0 {
            def Hallo(){}
            def Hallo2(){}
            }");
        }
    }
}

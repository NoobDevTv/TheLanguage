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
    public class MethodTests
    {
        ArrowCompiler compiler;

        public MethodTests()
        {
            compiler = new ArrowCompiler();
        }

        [TestMethod]
        public void MethodTest0()
        {
            var assembly = compiler.GetAssembly(@"
                def Test : void
             {
                }
                "
                );

            Assert.AreNotEqual(assembly, null);

        }

        [TestMethod]
        public void MethodTest1()
        {
            var assembly = compiler.GetAssembly(@"
                def Test : void
             {
                    var a = 1 + 1;
                }
                "
                 );

            Assert.AreNotEqual(assembly, null);
        }

        [TestMethod]
        public void MethodTest2()
        {
            var assembly = compiler.GetAssembly(@"
                def Test(a : int, b : int) : int
                {
                    ret a + b;
                }
                "
               );

            Assert.AreNotEqual(assembly, null);
        }

        [TestMethod]
        public void MethodTest3()
        {
            var assembly = compiler.GetAssembly(@"
                def Test() : int
                {
                }
                "
                           );

            Assert.AreNotEqual(assembly, null);
        }

        [TestMethod]
        public void MethodTest4()
        {
            var assembly = compiler.GetAssembly(@"
                def Test : int
                {
                }
                "
                           );

            Assert.AreNotEqual(assembly, null);
        }

        [TestMethod]
        public void MethodTest5()
        {
            var assembly = compiler.GetAssembly(@"
                def Test
                {
                }
                "
               );

            Assert.AreNotEqual(assembly, null);
        }
    }
}

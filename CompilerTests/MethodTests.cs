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
        public void MethodTestWithVoidAndEmpty()
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
        public void MethodTestWithCodeAndVoid()
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
        public void MethodTestWithParameterAndInt()
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
        public void MethodTestWithIntAndEmpty()
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
        public void MethodTestWithIntAndEmptyWithoutParaList()
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
        public void MethodTestEmptyWithoutReturnType()
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

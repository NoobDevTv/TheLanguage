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
            var result = compiler.RunFunc<int>(File.ReadAllText(@".\Test.arrow"));

            Assert.AreEqual(result(), 17);
        }

        [TestMethod]
        public void WhiteSpaceTest()
        {
            var compiler = new ArrowCompiler();
            Assert.AreEqual(compiler.RunFunc<int>(@"ret 1+1;")(), 2);
            Assert.AreEqual(compiler.RunFunc<int>(@"ret 1 + 1;")(), 2);
            Assert.AreEqual(compiler.RunFunc<int>(@" ret  1  +  1 ; ")(), 2);
            Assert.AreEqual(compiler.RunFunc<int>(@"var a= 2;ret a+1;")(), 3);
        }

        [TestMethod]
        public void NewLineTest()
        {
            var compiler = new ArrowCompiler();
            Assert.AreEqual(compiler.RunFunc<int>($"ret {Environment.NewLine}1 + 1;")(), 2);
            Assert.AreEqual(compiler.RunFunc<int>($"var {Environment.NewLine}a= 2;{Environment.NewLine}ret 1 + 1;")(), 2);
        }

        [TestMethod]
        public void MethodTest()
        {
            var compiler = new ArrowCompiler();
            var assembly = compiler.GetAssembly(@"
                def Test : void
	            {
                }
                "
                );
           assembly = compiler.GetAssembly(@"
                def Test : void
	            {
                    var a = 1 + 1;
                }
                "
               );

            //compiler.Run(@"
            //    def Test
            // {
            //    }
            //    "
            //   )();

            //compiler.Run(@"
            //    def Test() : int
            // {
            //    }
            //    "
            //   )();

            //compiler.Run(@"
            //    def Test(a : int, b : int) : int
            // {
            //    }
            //    "
            //   )();

        }
    }
}

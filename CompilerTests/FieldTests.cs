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
    public class FieldTests
    {
        private ArrowCompiler compiler;

        public FieldTests()
        {
            compiler = new ArrowCompiler();
        }

        [TestMethod]
        public void SimpleFieldTest()
        {
            compiler.GetAssembly(
               @"class test {
                    var global : int;
                  }");
        }
    }
}

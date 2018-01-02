using Arrow.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerTests
{
    [TestClass]
    public class FileTests
    {
        private ArrowCompiler compiler;

        public FileTests()
        {
            compiler = new ArrowCompiler();
        }

        [TestMethod]
        public void FileCompiling()
        {
            //TODO: an die Zunft diesen Fehler bzw. Test bitte lösen Gruß Vergangenheits Lassi und Marcus

            compiler.GetAssembly(File.ReadAllText(@"D:\Projekte\Visual 2017\TheLanguage\CompilerTests\SimpleTest.arrow"));
        }
    }
}

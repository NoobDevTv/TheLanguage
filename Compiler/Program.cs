using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using Newtonsoft.Json;
using System.IO;
using Arrow.Core;

namespace Compiler
{
    class Program
    {
        static void Main(string[] args)
        {
            var compiler = new ArrowCompiler();
            Console.WriteLine(compiler.RunVoid(""));

            Console.ReadLine();
        }
    }
}
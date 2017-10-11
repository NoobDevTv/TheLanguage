using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using Compiler.Scanning;
using Compiler.Parsing;
using Newtonsoft.Json;
using System.IO;

namespace Compiler
{
    class Program
    {
        static void Main(string[] args)
        {
            var compiler = new ArrowCompiler();
            Console.WriteLine(compiler.Run(""));

            Console.ReadLine();
        }
    }
}
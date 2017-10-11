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
            string input = "var alpha = 5; var beta = 6; ret alpha +2 *beta;";



            var tokenDefinitions = TokenDefinitionCollection.LoadFromIntern();
            

            Func<int> alpha = () => 5;

            var tokenizer = new Tokenizer(tokenDefinitions);

            var tokenResult = tokenizer.Parse(input);

            var parser = new Parser();

            var synatxTree = parser.Parse(tokenResult);

            var func = synatxTree.Visit();

            Console.WriteLine();
            Console.WriteLine(func());

            Console.ReadLine();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using Compiler.Scanning;
using Compiler.Parsing;

namespace Compiler
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "1 + 2 + 3 - 2";
            var tokenDefinitions = new List<TokenDefinition>() {
                new TokenDefinition("Integer", "[0-9]+"),
                new TokenDefinition("Space", " ", true),
                new TokenDefinition("Minus", "[-]"),
                new TokenDefinition("Plus", "[+]")
            };

            Func<int> alpha = () => 5;

            var tokenizer = new Tokenizer(tokenDefinitions);

            var tokenResult = tokenizer.Parse(input);

            var parser = new Parser();

            var synatxTree = parser.Parse(tokenResult);
        }
    }
}
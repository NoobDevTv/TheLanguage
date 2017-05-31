using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using Compiler.Base;

namespace Compiler
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "1 + 1";
                      
            var definitions = new List<TokenDefinition>() {
                new TokenDefinition("Integer", "[0-9]+"),
                new TokenDefinition("Space", " ", true),
                new TokenDefinition("Plus", "[+]")
            };

            var tokenizer = new Tokenizer(definitions);

            var result = tokenizer.Parse(input);
        }
    }
}

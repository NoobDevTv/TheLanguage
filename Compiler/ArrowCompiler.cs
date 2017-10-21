using Compiler.Parsing;
using Compiler.Scanning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    public class ArrowCompiler
    {
        public Func<int> Run(string input)
        {
            var tokenDefinitions = TokenDefinitionCollection.LoadFromIntern();            
            var tokenizer = new Tokenizer(tokenDefinitions);
            var tokenResult = tokenizer.Parse(input);
            var parser = new Parser();
            var synatxTree = parser.Parse(tokenResult);
            return synatxTree.Visit();
        }
    }
}

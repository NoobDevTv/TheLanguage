using Arrow.Core.Parsing;
using Arrow.Core.Scanning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Core
{
    public class ArrowCompiler
    {
        public Func<T> RunFunc<T>(string input)
        {
            var tokenDefinitions = TokenDefinitionCollection.LoadFromIntern();            
            var tokenizer = new Tokenizer(tokenDefinitions);
            var tokenResult = tokenizer.Parse(input);
            var parser = new Parser();
            var synatxTree = parser.Parse(tokenResult);
            return synatxTree.Visit<T>();
        }

        public Action RunVoid(string input)
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

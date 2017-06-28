using Compiler.Scanning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Parsing
{
    public class Parser
    {
        public List<SyntaxNodeDefinition> Defintions { get;  }


        public Parser(List<SyntaxNodeDefinition> defintion)
        {
            Defintions = defintion;
        }

        public SyntaxTree Parse(List<Token> tokens)
        {
            SyntaxTree tree = new SyntaxTree();

            foreach (var defintion in Defintions)
            {
                if (defintion.Check(tokens))
                {
                    Console.WriteLine($"{defintion} gefunden");
                }
            }

            return tree;
        }
    }
}

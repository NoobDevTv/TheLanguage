using Compiler.Parsing.Definition;
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
        Scanner scanner;

        public Parser()
        {
            scanner = new Scanner();
        }

        public SyntaxTree Parse(List<Token> tokens) => new SyntaxTree(Scanner.Scan(new SyntaxStream(tokens)));
            
        
    }
}

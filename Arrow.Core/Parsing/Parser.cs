using Arrow.Core.Parsing.Definition;
using Arrow.Core.Scanning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Core.Parsing
{
    public class Parser
    {
        Scanner scanner;

        public Parser()
        {
            scanner = new Scanner();
        }

        public SyntaxTree Parse(List<Token> tokens) => new SyntaxTree(scanner.Scan(new SyntaxStream(tokens)));
            
        
    }
}

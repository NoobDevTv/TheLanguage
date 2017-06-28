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

        public Parser()
        {
        }

        public SyntaxTree Parse(List<Token> tokens)
        {

            ExpressionSyntax expressions = new ExpressionSyntax();

            expressions.Check(tokens);

            return new SyntaxTree(expressions);
        }
    }
}

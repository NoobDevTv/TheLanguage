using Compiler.Parsing.Definition;

namespace Compiler.Parsing
{
    public class SyntaxTree
    {
        public ExpressionSyntax Expression { get; set; }

        public SyntaxTree(ExpressionSyntax syntax)
        {
            Expression = syntax;
        }
    }
}
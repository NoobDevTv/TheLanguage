using System;
using Arrow.Core.Parsing.Definition;
using Arrow.Core.Visitors;

namespace Arrow.Core.Parsing
{
    public class SyntaxTree
    {
        public Syntax Expression { get; set; }

        public SyntaxTree(Syntax syntax)
        {
            Expression = syntax;
        }

        public Func<int> Visit()
        {
            Scope scope = new Scope();

            CodeVisitor visitor = new CodeVisitor();

            visitor.Visit(Expression, scope);

            return scope.GetMethode();
        }
    }
}
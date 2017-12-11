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

        public Func<T> Visit<T>()
        {
            CodeScope scope = new CodeScope("Test",typeof(T));

            CodeVisitor visitor = new CodeVisitor();

            visitor.Visit(Expression, scope);

            return scope.GetMethode<T>();
        }

        public Action Visit()
        {
            CodeScope scope = new CodeScope("Test",null);

            CodeVisitor visitor = new CodeVisitor();

            visitor.Visit(Expression, scope);

            return scope.GetMethode();
        }
    }
}
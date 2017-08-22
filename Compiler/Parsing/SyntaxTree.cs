using System;
using Compiler.Parsing.Definition;
using Compiler.Visitors;

namespace Compiler.Parsing
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
            Expression.Visit(scope);

            return scope.GetMethode();
        }
    }
}
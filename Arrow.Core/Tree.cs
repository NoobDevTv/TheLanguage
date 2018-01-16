using System;

namespace Arrow.Core.Parsing
{
    public abstract class Tree
    {
        public Syntax Expression { get; set; }

        public Tree(Syntax syntax)
        {
            Expression = syntax;
        }
        
    }
}
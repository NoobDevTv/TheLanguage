using System;

namespace Arrow.Core
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
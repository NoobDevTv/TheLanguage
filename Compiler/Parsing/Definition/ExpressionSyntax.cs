using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler.Scanning;

namespace Compiler.Parsing.Definition
{
    public class ExpressionSyntax : Syntax
    {

        public Syntax Expression { get; set; }

        public ExpressionSyntax() 
            : base(nameof(ExpressionSyntax))
        {
        }

        public override bool Check(List<Token> tokens)
        {
            Expression = new SubstractionSyntax();
            if (Expression.Check(tokens))
                return true;

            Expression = new AdditionSyntax();
            if(Expression.Check(tokens))
                return true;

            Expression = new IntegerSyntax();
            if (Expression.Check(tokens))
                return true;

            return false;
        }
    }
}

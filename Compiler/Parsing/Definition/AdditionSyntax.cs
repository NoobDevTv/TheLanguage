using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler.Scanning;

namespace Compiler.Parsing.Definition
{
    public class AdditionSyntax : Syntax
    {
        public ExpressionSyntax Left { get; set; }
        public ExpressionSyntax Right { get; set; }

        public AdditionSyntax() 
            : base(nameof(AdditionSyntax))
        {
        }

        public override bool Check(List<Token> tokens)
        {

            if (tokens.Count < 3)
                return false;

            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i].Name == "Plus" )
                {
                    Left = new ExpressionSyntax();
                    Right = new ExpressionSyntax();

                    if (Left.Check(tokens.Take(i).ToList()) && Right.Check(tokens.Skip(i+1).ToList()))
                        return true;
                }
            }

            return false;
        }
    }
}

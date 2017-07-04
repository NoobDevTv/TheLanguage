using Compiler.Scanning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Parsing.Definition
{
    public class SubstractionSyntax : Syntax
    {
        public ExpressionSyntax Left { get; set; }
        public ExpressionSyntax Right { get; set; }

        public SubstractionSyntax() 
            : base(nameof(SubstractionSyntax))
        {
        }

        public override bool Check(List<Token> tokens)
        {

            if (tokens.Count < 3)
                return false;

            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i].Name == "Minus")
                {
                    Left = new ExpressionSyntax();
                    Right = new ExpressionSyntax();

                    if (Left.Check(tokens.Take(i).ToList()) && Right.Check(tokens.Skip(i + 1).ToList()))
                        return true;
                }
            }

            return false;
        }
    }
}

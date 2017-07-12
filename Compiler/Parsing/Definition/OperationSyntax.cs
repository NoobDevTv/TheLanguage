using Compiler.Scanning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Parsing.Definition
{
    public abstract class OperationSyntax : Syntax
    {
        public ExpressionSyntax Left { get; set; }
        public ExpressionSyntax Right { get; set; }

        public string TokenName { get; }

        public OperationSyntax(string name,string tokenName) : base(name)
        {
            TokenName = tokenName;
        }

        public override bool Check(SyntaxStream syntaxStream)
        {
            if (syntaxStream.Count == 3)
                return false;

            for (int i = 0; i < syntaxStream.Count; i++)
            {
                if (syntaxStream[i].Name == TokenName)
                {
                    Left = new ExpressionSyntax();
                    Right = new ExpressionSyntax();

                    if (Left.Check(syntaxStream.Take(i)) && Right.Check(syntaxStream.Skip(i + 1)))
                        return true;
                }
            }

            return false;
        }
    }
}

using Compiler.Scanning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Parsing.Definition
{
    public class TokenSyntax : Syntax
    {
        public Token Token { get; }

        public TokenSyntax(Token token) 
            : base(nameof(TokenSyntax))
        {
            Token = token;
        }

        public override bool Check(SyntaxStream syntaxStream)
        {
            return true;
        }
    }
}

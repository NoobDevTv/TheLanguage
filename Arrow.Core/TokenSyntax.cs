using Arrow.Core.Scanning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Core
{
    public class TokenSyntax : Syntax
    {
        public Token Token { get; }

        public TokenSyntax(Token token)
            : base()
        {
            Token = token;
            Name = token.Name;
        }

        public override string ToString() => Name;

        public override bool TryParse(SyntaxStream stream, Scanner scanner) => false;
    }
}

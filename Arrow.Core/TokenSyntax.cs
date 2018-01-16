using Arrow.Core.Scanning;
using Arrow.Core.Visitors;
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
            : base(nameof(TokenSyntax))
        {
            Token = token;
            Name = token.Name;
        }

        public override string ToString() => Name;

        public override bool TryParse(SyntaxStream stream, Scanner scanner) => false;
    }
}

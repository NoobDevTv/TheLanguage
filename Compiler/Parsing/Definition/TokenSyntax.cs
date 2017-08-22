using Compiler.Scanning;
using Compiler.Visitors;
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
            Name = token.Name;
        }

        public override string ToString() => Name;

        public override bool TryParse(SyntaxStream stream, Scanner scanner) => false;

        public override void Visit(Scope scope)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arrow.Core.Visitors;
using System.Reflection.Emit;

namespace Arrow.Core.Parsing.Definition
{
    [Syntax(SyntaxDefinitionType.Identifier)]
    public class IdentifierSyntax : Syntax
    {        
        public IdentifierSyntax() : base(nameof(IdentifierSyntax))
        {
        }

        public string Name { get; private set; }

        public override bool TryParse(SyntaxStream stream, Scanner scanner)
        {

            if (stream.Count != 1)
                return false;

            if (stream[0] is TokenSyntax tokenSyntax)
            {
                if (tokenSyntax.Name == "Identifier")
                {
                    Position = stream.GlobalPosition;
                    Length = 1;
                    Name =tokenSyntax.Token.Value;
                    return true;
                }
            }

            return false;
        }
    }
}

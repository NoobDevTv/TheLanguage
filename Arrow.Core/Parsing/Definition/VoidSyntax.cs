using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Core.Parsing.Definition
{
    [Syntax(SyntaxDefinitionType.Void)]
    public class VoidSyntax : TypeSyntax
    {
        public VoidSyntax() : base(nameof(VoidSyntax))
        {
        }

        public override bool TryParse(SyntaxStream stream, Scanner scanner)
        {
            if (stream.Count != 1)
                return false;

            if (stream[0] is TokenSyntax tokenSyntax)
            {
                if (tokenSyntax.Name == "Void")
                    return true;
            }

            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Core.Parsing.Definition
{
    [Syntax(SyntaxDefinitionType.FieldDeclaration)]
    public class FieldDeclarationSyntax : VariableDeclarationSyntax
    {
        public FieldDeclarationSyntax() : base(nameof(FieldDeclarationSyntax))
        {

        }

        public override bool TryParse(SyntaxStream stream, Scanner scanner)
        {
            for (int i = 0; i < stream.Count; i++)
            {
                if (stream[i].Name == "CodeLineEnd")
                {
                    var result = base.TryParse(stream.Take(i), scanner);
                    Length += 1;
                    return result;
                }
            }

            return false;
            
        }
    }
}

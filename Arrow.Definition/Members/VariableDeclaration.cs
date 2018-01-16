using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using Arrow.Core.Basemembers;

namespace Arrow.Definition.Members
{
    public class VariableDeclaration : VariableDeclarationBase
    {
                
        public override bool TryParse(SyntaxStream stream, Scanner scanner)
        {
            var result = false;

            if (stream.Count < 2)
                return false;

            if (stream[0].Name == "Var" && stream[1].Name == "Identifier")
            {
                var identifierToken = (TokenSyntax)stream[1];
                Name = identifierToken.Token.Value;
                Position = stream.GlobalPosition;
                Length = 2;

                result = true;
            }

            if(stream.Count > Length && scanner.TryScan(stream.Skip(Length),out TypeDeclarationSyntax type))
            {
                TypeDeclarationSyntax = type;
                Length += type.Length;
            }

            if ( stream.Count > Length &&stream[Length].Name == "AssignEquals")
            {
                Expression = scanner.Scan(stream.Skip(Length + 1));
                Length += 1 + Expression.Length;
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using Arrow.Core.Basemembers;

namespace Arrow.Definition.Members
{
    public class ParameterDeclaration : VariableDeclarationBase
    {
        public ParameterDeclaration() 
        {
            IsParameter = true;
        }
        
        public override bool TryParse(SyntaxStream stream, Scanner scanner)
        {
            var result = false;

            if (stream[0].Name == "Identifier"
                && scanner.TryScan(stream.Skip(1), out TypeDeclarationSyntax typeDeclarationSyntax))
            {
                var identifierToken = (TokenSyntax)stream[0];
                Name = identifierToken.Token.Value;
                TypeDeclaration = typeDeclarationSyntax;
                Position = stream.GlobalPosition;
                Length = 1 + typeDeclarationSyntax.Length;

                result = true;
            }


            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arrow.Core.Visitors;
using System.Reflection.Emit;

namespace Arrow.Core.Parsing.Definition
{
    public class ParameterDeclarationSyntax : Syntax
    {
        public Syntax Expression { get; private set; }
        public TypeDeclarationSyntax TypeDeclaration { get; private set; }

        public ParameterDeclarationSyntax() : base(nameof(ParameterDeclarationSyntax))
        {
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

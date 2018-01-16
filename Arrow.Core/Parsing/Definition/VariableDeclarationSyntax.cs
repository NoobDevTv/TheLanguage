using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arrow.Core.Visitors;
using System.Reflection.Emit;

namespace Arrow.Core.Parsing.Definition
{
    [Syntax(SyntaxDefinitionType.Variable)]
    public class VariableDeclarationSyntax : Syntax
    {
        public Syntax Expression { get; protected set; }

        public TypeDeclarationSyntax TypeDeclarationSyntax { get; set; }

        public VariableDeclarationSyntax() : base(nameof(VariableDeclarationSyntax))
        {
        }
        protected VariableDeclarationSyntax(string name) : base(name)
        {

        }
        
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

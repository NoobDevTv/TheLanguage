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
        public VariableDeclarationSyntax() : base(nameof(VariableDeclarationSyntax))
        {
        }
        
        public Syntax Expression { get; private set; }

        public override bool TryParse(SyntaxStream stream, Scanner scanner)
        {
            var result = false;

            if (stream[0].Name == "Var" && stream[1].Name == "Identifier")
            {
                var identifierToken = (TokenSyntax)stream[1];
                Name = identifierToken.Token.Value;

                result = true;
            }

            if ( stream.Count > 2 &&stream[2].Name == "AssignEquals")
            {
                Expression = scanner.Scan(stream.Skip(3));
            }

            return result;
        }
    }
}

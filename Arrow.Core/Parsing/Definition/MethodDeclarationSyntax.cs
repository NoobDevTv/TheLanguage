using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Core.Parsing.Definition
{
    class MethodDeclarationSyntax : Syntax
    {
        public IdentifierSyntax Identifier { get; private set; }
        public TypeDeclarationSyntax DeclarationSyntax { get; private set; }

        public MethodDeclarationSyntax() : base(nameof(MethodDeclarationSyntax))
        {
        }

        public override bool TryParse(SyntaxStream stream, Scanner scanner)
        {
            var result = false;

            if (stream.Count < 4) //Because you need a method body
                return false;

            if (stream[0].Name == "MethodDeclaration" && stream[1].Name == "Identifier")
            {
                Identifier = (IdentifierSyntax)scanner.Scan(stream.Get(1, 1));
                result = true;
            }
            

            return result;
        }
    }
}

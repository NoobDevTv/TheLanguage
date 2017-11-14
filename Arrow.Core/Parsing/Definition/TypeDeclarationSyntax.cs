using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Core.Parsing.Definition
{
    [Syntax(SyntaxDefinitionType.TypeDeclaration)]
    class TypeDeclarationSyntax : Syntax
    {
        public TypeSyntax TypeSyntax { get; private set; }

        public TypeDeclarationSyntax() : base(nameof(TypeDeclarationSyntax))
        {
        }

        public TypeDeclarationSyntax(TypeSyntax typeSyntax)
            : this()
        {
            TypeSyntax = typeSyntax;
        }

        public override bool TryParse(SyntaxStream stream, Scanner scanner)
        {
            if (stream.Count < 2)
                return false;

            if (stream[0].Name == "TypeDeclaration")
            {
                TypeSyntax = scanner.Scan(stream.Skip(1)) as TypeSyntax;
                return TypeSyntax != null;
            }

            return false;
        }
    }
}

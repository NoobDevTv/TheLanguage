using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Core.Parsing.Definition
{
    class TypeDeclarationSyntax : Syntax
    {
        public Syntax Expression { get; private set; }

        public TypeDeclarationSyntax() : base(nameof(TypeDeclarationSyntax))
        {
        }


        public override bool TryParse(SyntaxStream stream, Scanner scanner)
        {
            if (stream.Count < 2)
                return false;

            if (stream[0].Name == "TypeDeclaration")
            {
                Expression = scanner.Scan(stream.Skip(1));
                return Expression is VoidSyntax;
            }

            return false;
        }
    }
}

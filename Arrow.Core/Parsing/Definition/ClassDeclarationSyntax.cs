using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Core.Parsing.Definition
{
    [Syntax(SyntaxDefinitionType.ClassDeclaration)]
    class ClassDeclarationSyntax : Syntax
    {
        public IdentifierSyntax Identifier { get; private set; }
        public ScopeSyntax Body { get; set; }
        //BaseClass

        public ClassDeclarationSyntax() : base(nameof(ClassDeclarationSyntax))
        {
        }

        public override bool TryParse(SyntaxStream stream, Scanner scanner)
        {

            if (stream.Count < 3)
                return false;

            if (stream[0].Name == "ClassDeclaration" && stream[1].Name == "Identifier")
            {
                if(scanner.TryScan(stream.Get(1, 1), out IdentifierSyntax identifierSyntax))
                {
                    Identifier = identifierSyntax;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }

            if (stream[2].Name == "CodeLineEnd")
            {
                return true;
            }

            return false;
        }
    }
}

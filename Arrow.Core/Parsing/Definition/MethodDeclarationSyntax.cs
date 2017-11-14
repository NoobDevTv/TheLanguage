using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Core.Parsing.Definition
{
    [Syntax(SyntaxDefinitionType.MethodDeclaration)]
    class MethodDeclarationSyntax : Syntax
    {
        public IdentifierSyntax Identifier { get; private set; }
        public TypeDeclarationSyntax DeclarationSyntax { get; private set; }
        public ScopeSyntax Body { get; private set; }
        public ParentSyntax Signature { get; private set; }

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
                //Parent?
                if(scanner.TryScan(stream.Get(2, 2), out TypeDeclarationSyntax typeDeclarationSyntax))
                {
                    DeclarationSyntax = typeDeclarationSyntax;
                    Body = (ScopeSyntax)scanner.Scan(stream.Skip(4));
                }
                else if(scanner.TryScan(stream.Skip(2), out ScopeSyntax scopeSyntax))
                {
                    DeclarationSyntax = new TypeDeclarationSyntax(new VoidSyntax());
                    Body = scopeSyntax;
                }
                else
                {
                    return false;
                }
                
                
                result = true;
            }


            return result;
        }
    }
}

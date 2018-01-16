using Arrow.Core.Basemembers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Definition.Members
{
    class MethodDeclaration : MethodDeclarationBase
    {

        public override bool TryParse(SyntaxStream stream, Scanner scanner)
        {
            if (stream.Count < 4) //Because you need a method body
                return false;

            if (!(stream[0].Name == "MethodDeclaration" && stream[1].Name == "Identifier"))
                return false;

            Identifier = (IdentifierSyntax)scanner.Scan(stream.Get(1, 1));
            Position = stream.GlobalPosition;

            int index = 2;

            if (scanner.TryScan(stream.Skip(index), out ParameterListSyntax parentSyntax))
            {
                Signature = parentSyntax;
                index += parentSyntax.Count;
            }

            if (scanner.TryScan(stream.Get(index, 2), out TypeDeclarationSyntax typeDeclarationSyntax))
            {
                DeclarationSyntax = typeDeclarationSyntax;
                Body = (Block)scanner.Scan(stream.Skip(index + 2));
            }
            else if (scanner.TryScan(stream.Skip(index), out Block scopeSyntax))
            {
                DeclarationSyntax = new TypeDeclarationSyntax(new PrimitiveSyntax());
                Body = scopeSyntax;
            }
            else
            {
                return false;
            }

            Length = index + Body.Length + DeclarationSyntax.Length;

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Core.Parsing.Definition
{
    //[Syntax(SyntaxDefinitionType.NamespaceDeclaration)]
    class NamespaceDeclarationSyntax : Syntax
    {
        public IdentifierSyntax Identifier { get; private set; }
        //public ScopeSyntax Body { get; set; }
        public List<Syntax> MemberList { get; private set; }

        public NamespaceDeclarationSyntax() : base(nameof(NamespaceDeclarationSyntax))
        {
            MemberList = new List<Syntax>();
        }

        public override bool TryParse(SyntaxStream stream, Scanner scanner)
        {
            var index = 0;

            do
            {
                var substream = stream.Skip(index);

                if (scanner.TryScan(substream, out MethodDeclarationSyntax methodDeclaration))
                {
                    MemberList.Add(methodDeclaration);
                }
                else if (scanner.TryScan(substream, out ClassDeclarationSyntax classDeclaration))
                {
                    MemberList.Add(classDeclaration);
                }
                else
                {
                    throw new Exception($"{substream[0]?.Name} is not valid in Namespace");
                }

                index += MemberList.Last().Length;

            } while (index < stream.Count);

            return true;
        }
    }
}


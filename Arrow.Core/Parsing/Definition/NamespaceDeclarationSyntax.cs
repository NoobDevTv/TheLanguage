using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Core.Parsing.Definition
{
    [Syntax(SyntaxDefinitionType.NamespaceDeclaration)]
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

            if (scanner.TryScan(stream, out MethodDeclarationSyntax methodDeclaration))
            {
                MemberList.Add(methodDeclaration);
            }
            else if (scanner.TryScan(stream, out ClassDeclarationSyntax classDeclaration))
            {
                MemberList.Add(classDeclaration);                
            }
            else
            {
                throw new Exception($"{stream[0]?.Name} is not valid in Namespace");
            }


            return true;
        }
    }
}


using Arrow.Core.Basemembers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Definition.Members
{
    class NamespaceDeclaration : NamespaceDeclarationBase
    {

        public override bool TryParse(SyntaxStream stream, Scanner scanner)
        {
            var index = 0;

            do
            {
                var substream = stream.Skip(index);

                if (scanner.TryScan(substream, out MethodDeclaration methodDeclaration))
                {
                    MemberList.Add(methodDeclaration);
                }
                else if (scanner.TryScan(substream, out ClassDeclaration classDeclaration))
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


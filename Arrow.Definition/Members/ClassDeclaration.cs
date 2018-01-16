using Arrow.Core;
using Arrow.Core.Basemembers;
using Arrow.Definition.Keywords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Definition.Members
{
    class ClassDeclaration : ClassDeclarationBase
    {
        public override bool TryParse(SyntaxStream stream, Scanner scanner)
        {
            if (stream.Count < 3)
                return false;

            var index = 0;

            if (stream[0].Name == "ClassDeclaration" && stream[1].Name == "Identifier")
            {
                if (scanner.TryScan(stream.Get(1, 1), out Identifier identifierSyntax))
                {
                    Identifier = identifierSyntax;
                    Position = stream.GlobalPosition;
                    index += 2;
                }
                else
                {
                    return false;
                }

                if (stream[2].Name == "LowerThan")
                {
                    if (scanner.TryScan(stream.Skip(3), out ComplexType baseType))
                    {
                        BaseClass = baseType;
                        index += 1 + baseType.Length;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            else
            {
                return false;
            }

            if (stream[index].Name == "CodeLineEnd")
            {
                Length = index + 1;
                return true;
            }
            else if (scanner.TryScan(stream.Skip(index), out Block scope))
            {
                Length = index + scope.Length;
                Body = scope;
                return true;
            }
            else
            {

            }

            return false;
        }
    }
}

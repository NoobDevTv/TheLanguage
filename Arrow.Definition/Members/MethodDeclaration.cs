using Arrow.Core;
using Arrow.Core.Basekeywords;
using Arrow.Core.Basemembers;
using Arrow.Definition.Keywords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Definition.Members
{
    class MethodDeclaration : MethodDeclarationBase
    {

        public override bool TryParse(TokenStream stream, Scanner scanner)
        {
            if (stream.Count < 4) //Because you need a method body
                return false;

            if (stream[0].Name != "MethodDeclaration")
                return false;

            Identifier identifier = null;
            ParameterList parameterList = null;
            TypeKeyword type = null;
            Block block = null;

            int index = 0;

            if (!scanner.TryScan(stream.Get(1, 1), out identifier))
                return false;

            if (scanner.TryScan(stream.Skip(2),out parameterList))
            {
                index += parameterList.Length;
            }

            if (stream.Count >= index && stream[index].Name == "TypeDeclaration")
            {
                if (scanner.TryScan(stream.Get(index, 1), out ComplexType complexType))
                {
                    type = complexType;
                }
                else if (scanner.TryScan(stream.Get(index, 1), out Primitive primitivType))
                {
                    type = primitivType;
                }
                else
                {
                    //TODO:Error
                    return false;
                }

                index += 2;
            }

            if (!scanner.TryScan(stream.Skip(index), out block))
                return false;

            Body = block;
            DeclarationSyntax = type;
            Identifier = identifier;
            Signature = parameterList;
            Position = stream.GlobalPosition;
            Length = index + block.Length;

            return true;
        }
    }
}

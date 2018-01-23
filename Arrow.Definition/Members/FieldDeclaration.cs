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
    public class FieldDeclaration : FieldDeclarationBase
    {

        public override bool TryParse(TokenStream stream, Scanner scanner)
        {
            Identifier identifier = null;
            TypeKeyword type = null;

            if (stream[0].Name != "Var")
                return false;

            if (!scanner.TryScan(stream.Get(1, 1), out identifier))
                return false;

            int index = 2;

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

            if (stream.Count < index || stream[index].Name != "CodeLineEnd")
                return false;

            Position = stream.GlobalPosition;
            Length = index + 1;
            Identifier = Identifier;
            Type = type;

            return true;

        }
    }
}

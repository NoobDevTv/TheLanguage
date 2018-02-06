using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using Arrow.Core.Basemembers;
using Arrow.Core;
using Arrow.Definition.Keywords;

namespace Arrow.Definition.Members
{
    public class ParameterDeclaration : VariableDeclarationBase
    {
        public ParameterDeclaration()
        {
            IsParameter = true;
        }

        public override bool TryParse(TokenStream stream, Scanner scanner)
        {
            var result = false;

            if (stream.Count < 3)
                return false;

            if (scanner.TryScan(stream.Take(1), out Identifier identifier))
                Identifier = identifier;
            else
                return false;

            if (stream[1].Name != "TypeDeclaration")
                return false;

            if (scanner.TryScan(stream.Skip(2), out ComplexType complexType))
            {
                Type = complexType;
            }
            else if (scanner.TryScan(stream.Skip(2), out Primitive primitive))
            {
                Type = primitive;
            }
            else
            {
                return false;
            }

            Position = stream.GlobalPosition;
            Length = 2 + Type.Length;
            
            return result;
        }
    }
}

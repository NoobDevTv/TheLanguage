using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using Arrow.Core.Basemembers;
using Arrow.Core;
using Arrow.Definition.Keywords;
using Arrow.Definition.Statements;

namespace Arrow.Definition.Members
{
    public class VariableDeclaration : VariableDeclarationBase
    {
                
        public override bool TryParse(TokenStream stream, Scanner scanner)
        {
            if (stream.Count < 3)
                return false;

            if (stream[0].Name != "Var")
                return false;

            if (scanner.TryScan(stream.Skip(1), out Identifier identifier))
                Identifier = identifier;
            else
                return false;
        
            var index = 2;
            if(stream[index].Name == "TypeDeclaration")
            {
                index++;

                if(scanner.TryScan(stream.Skip(index), out ComplexType complexType))
                {
                    Type = complexType;
                } else if(scanner.TryScan(stream.Skip(index), out Primitive primitive))
                {
                    Type = primitive;
                }
                else
                {
                    return false;
                }

                index += Type.Length;
            }

            if(stream[index].Name == "AssignEquals")
            {
                index++;

                if(scanner.TryScan(stream.Skip(index), out Operation operation)) //TODO: Expression
                {
                    throw new NotImplementedException(":( this is currently not implemented");
                }
            }

            if (stream[index].Name != "CodeLineEnd")
                return false;

            Length = index + 1;

            return true;
        }
    }
}

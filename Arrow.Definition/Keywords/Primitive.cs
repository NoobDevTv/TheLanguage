using Arrow.Core.Basekeywords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Definition.Keywords
{
    public class Primitive : TypeKeyword
    {

        public override bool TryParse(SyntaxStream stream, Scanner scanner)
        {
            if (stream.Count != 1)
                return false;

            if (stream[0] is TokenSyntax tokenSyntax)
            {
                switch (tokenSyntax.Name)
                {
                    case "Void":
                        Type = null;
                        break;
                    case "Int":
                        Type = typeof(Int32);
                        break;
                    case "Short":
                        Type = typeof(Int16);
                        break;
                    case "Long":
                        Type = typeof(Int64);
                        break;
                    case "Float":
                        Type = typeof(Single);
                        break;
                    case "Decimal":
                        Type = typeof(Decimal);
                        break;
                    case "Double":
                        Type = typeof(Double);
                        break;
                    case "String":
                        Type = typeof(String);
                        break;
                    case "Char":
                        Type = typeof(Char);
                        break;
                    case "Bool":
                        Type = typeof(Boolean);
                        break;
                    case "Object":
                        Type = typeof(Object);
                        break;
                    case "UShort":
                        Type = typeof(UInt16);
                        break;
                    case "UInt":
                        Type = typeof(UInt32);
                        break;
                    case "ULong":
                        Type = typeof(UInt64);
                        break;
                    case "Byte":
                        Type = typeof(Byte);
                        break;
                    case "SByte":
                        Type = typeof(SByte);
                        break;
                    default:
                        return false;
                }

                Position = stream.GlobalPosition;
                Length = 1;

                return true;
            }

            return false;
        }
    }
}

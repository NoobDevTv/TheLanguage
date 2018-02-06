using Arrow.Core;
using Arrow.Core.Basekeywords;
using Arrow.Core.Scanning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Definition.Keywords
{
    public class Primitive : TypeKeyword
    {

        public override bool TryParse(TokenStream stream, Scanner scanner)
        {
            if (stream.Count != 1)
                return false;

            if (stream[0] is Token token)
            {
                switch (token.Name)
                {
                    case "Void":
                        Value = "void";
                        break;
                    case "Int":
                        Value = "int32_t";
                        break;
                    case "Short":
                        Value = "int16_t";
                        break;
                    case "Long":
                        Value = "int64_t";
                        break;
                    case "Float":
                        Value = "float";
                        break;
                    case "Decimal":
                        Value = "decimal";
                        break;
                    case "Double":
                        Value = "double";
                        break;
                    case "String":
                        Value = "string";
                        break;
                    case "Char":
                        Value = "char";
                        break;
                    case "Bool":
                        Value = "boolean";
                        break;
                    case "Object":
                        Value = "object";
                        break;
                    case "UShort":
                        Value = "uint16_t";
                        break;
                    case "UInt":
                        Value = "uint32_t";
                        break;
                    case "ULong":
                        Value = "uint64_t";
                        break;
                    case "Byte":
                        Value = "int8_t";
                        break;
                    case "SByte":
                        Value = "uint8_t";
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

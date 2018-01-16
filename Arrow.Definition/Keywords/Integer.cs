using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using Arrow.Core.Basekeywords;

namespace Arrow.Definition.Keywords
{
    public class Integer : IntegerKeyword
    {

        public override bool TryParse(SyntaxStream stream, Scanner scanner)
        {
            if (stream.Count != 1)
                return false;

            if (stream[0] is TokenSyntax tokenSyntax)
            {
                if (tokenSyntax.Name == "Integer")
                {
                    Value = int.Parse(tokenSyntax.Token.Value);
                    Position = stream.GlobalPosition;
                    Length = 1;
                    return true;
                }
            }

            return false;
        }
    }
}

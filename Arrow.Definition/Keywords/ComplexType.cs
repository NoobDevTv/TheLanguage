using Arrow.Core;
using Arrow.Core.Basekeywords;
using Arrow.Core.Scanning;

namespace Arrow.Definition.Keywords
{
    public class ComplexType : TypeKeyword
    {
        public override bool TryParse(TokenStream stream, Scanner scanner)
        {
            if(stream[0] is Token token)
            {
                if(token.Name == "Identifier")
                {
                    Value = token.Value;
                    Position = stream.GlobalPosition;
                    Length = 1;
                    return true;
                }
            }

            return false;
        }
    }
}
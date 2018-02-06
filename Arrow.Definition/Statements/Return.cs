using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using Arrow.Core.Basestatements;
using Arrow.Core;

namespace Arrow.Definition.Statements
{
    public class Return : ReturnStatement
    {
        public override bool TryParse(TokenStream stream, Scanner scanner)
        {
            if (stream.Count < 2)
                return false;

            if (stream[0].Name == "Return")
            {
                Expression = scanner.Scan(stream.Skip(1)); //TODO: IExpression

                Position = stream.GlobalPosition;
                Length = 1 + Expression.Length;

                return true;
            }

            return false;
        }
    }
}

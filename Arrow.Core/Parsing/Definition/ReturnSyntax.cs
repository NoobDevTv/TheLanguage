using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arrow.Core.Visitors;
using System.Reflection.Emit;

namespace Arrow.Core.Parsing.Definition
{
    [Syntax(SyntaxDefinitionType.Return)]
    public class ReturnSyntax : Syntax
    {
        public Syntax Expression { get; private set; }

        public ReturnSyntax() : base(nameof(ReturnSyntax))
        {
        }

        public override bool TryParse(SyntaxStream stream, Scanner scanner)
        {
            if (stream.Count < 2)
                return false;

            if (stream[0].Name == "Return")
            {
                Expression = scanner.Scan(stream.Skip(1));
                return true;
            }

            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler.Scanning;

namespace Compiler.Parsing.Definition
{
    [Syntax(0)]
    public class IntegerSyntax : Syntax
    {
        public int Value { get; private set; }

        public IntegerSyntax()
            : base(nameof(IntegerSyntax))
        {
        }

        public override bool TryParse(SyntaxStream stream, Scanner scanner)
        {
            if (stream.Count != 1)
                return false;

            if (stream[0] is TokenSyntax tokenSyntax)
            {
                if (tokenSyntax.Name == "Integer")
                {
                    Value = int.Parse(tokenSyntax.Token.Value);
                    stream.Replace(this, 0, 1);
                    return true;
                }
            }

            return false;
        }
    }
}

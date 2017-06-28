using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler.Scanning;

namespace Compiler.Parsing.Definition
{
    public class IntegerSyntax : Syntax
    {
        public int Value { get; set; }

        public IntegerSyntax() 
            : base(nameof(IntegerSyntax))
        {
        }

        public override bool Check(List<Token> tokens)
        {
            if (tokens.Count != 1)
                return false;

            if (tokens[0].Name == "Integer")
            {
                Value = int.Parse(tokens[0].Value);
                return true;
            }

            return false;
        }
    }
}

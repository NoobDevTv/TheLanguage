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

        public override bool Check(SyntaxStream syntaxStream)
        {
            /*
            if (syntaxStream.Count != 1)
                return false;

            if (syntaxStream[0].Name == "Integer")
            {
                Value = int.Parse(syntaxStream[0].Value);
                return true;
            }
            */

            return false;
        }
    }
}

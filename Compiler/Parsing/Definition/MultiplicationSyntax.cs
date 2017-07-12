using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Parsing.Definition
{
    public class MultiplicationSyntax : OperationSyntax
    {
        public MultiplicationSyntax() 
            : base(nameof(MultiplicationSyntax), "Point")
        {
        }
    }
}

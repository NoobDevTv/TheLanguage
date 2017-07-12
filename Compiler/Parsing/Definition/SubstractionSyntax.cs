using Compiler.Scanning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Parsing.Definition
{
    public class SubstractionSyntax : OperationSyntax
    {
        
        public SubstractionSyntax() 
            : base(nameof(SubstractionSyntax),"Minus")
        {
        }
    }
}

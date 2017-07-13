using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler.Scanning;

namespace Compiler.Parsing
{
    public abstract class Syntax : IScanable
    {

        public string Name { get; set; }

        public Syntax(string name )
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
        
        public abstract bool TryParse(SyntaxStream stream, Scanner scanner, out Syntax syntax);
    }
}

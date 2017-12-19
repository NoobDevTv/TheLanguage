using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arrow.Core.Scanning;
using Arrow.Core.Visitors;

namespace Arrow.Core.Parsing
{
    public abstract class Syntax : IScanable
    {
        public int Position { get; set; }
        public int Length { get; set; }

        public string Name { get; protected set; }

        public Syntax(string name )
        {
            Name = name;
        }

        public override string ToString() => Name;
                
        public abstract bool TryParse(SyntaxStream stream, Scanner scanner);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arrow.Core.Scanning;

namespace Arrow.Core
{
    public abstract class Syntax
    {
        public int Position { get; set; }
        public int Length { get; set; }

        public string Name { get; protected set; }

        public Syntax()
        {
            Name = GetType().Name;
        }

        public override string ToString() => Name;

        public abstract bool TryParse(TokenStream stream, Scanner scanner);
    }
}

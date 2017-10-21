using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Compiler.Scanning
{
    public class TokenDefinition
    {
        public string Name { get; set; }
        public Regex Expression { get; set; }

        public int Order { get; set; }

        public bool Skip { get; set; }

        private TokenDefinition()
        {
            Order = 0; //TODO;
        }

        public TokenDefinition(string name, string pattern) : this()
        {
            Name = name;
            Expression = new Regex(pattern);
        }

        public TokenDefinition(string name, string pattern, bool skip) : this(name, pattern)
        {
            Skip = skip;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Compiler.Base
{
    public class TokenDefinition
    {
        public string Name { get; private set; }
        public Regex Expression { get; private set; }

        public bool Skip { get; private set; }

        public TokenDefinition(string name, string pattern)
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

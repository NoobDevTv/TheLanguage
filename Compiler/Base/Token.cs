using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Compiler.Base
{
    public class Token
    {
        private Match result;

        public Token(Match result, TokenDefinition definition)
        {
            this.result = result;
            Definition = definition;
        }

        public string Name { get; set; }
        public int Position { get; set; }
        public int Length { get; set; }
        public string Value { get; set; }
        public TokenDefinition Definition { get; set; }
    }
}

using Arrow.Core.Scanning;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arrow.Core.Basemembers
{
    public abstract class BlockBase : Member
    {
        public Token Open { get; protected set; }
        public Token Close { get; protected set; }

        public int Count { get; set; }
        public bool AllowEmpty { get; protected set; }

        public List<Member> Members { get; set; }        
    }
}

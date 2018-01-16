using System;
using System.Collections.Generic;
using System.Text;

namespace Arrow.Core.Basemembers
{
    public abstract class BlockBase : Member
    {
        public Keyword Open { get; private set; }
        public Keyword Close { get; private set; }

        public int Count { get; set; }
        public bool AllowEmpty { get; protected set; }

        public List<Member> Members { get; set; }        
    }
}

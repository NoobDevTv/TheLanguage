using System;
using System.Collections.Generic;
using System.Text;

namespace Arrow.Core.Basemembers
{
    public abstract class MemberListBase : Member
    {
        public List<Member> Members { get; set; }
    }
}

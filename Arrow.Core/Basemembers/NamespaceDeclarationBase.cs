using Arrow.Core.Basekeywords;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arrow.Core.Basemembers
{
    public abstract class NamespaceDeclarationBase : Member
    {
        public IdentifierKeyword Identifier { get; private set; }
        //public ScopeSyntax Body { get; set; }
        public List<Member> MemberList { get; private set; }
    }
}

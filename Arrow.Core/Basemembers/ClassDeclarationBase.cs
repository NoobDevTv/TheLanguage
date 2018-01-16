using Arrow.Core.Basekeywords;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arrow.Core.Basemembers
{
    public abstract class ClassDeclarationBase : Member
    {
        public IdentifierKeyword Identifier { get; private set; }
        public BlockBase Body { get; set; }
        public Member BaseClass { get; set; }
    }
}

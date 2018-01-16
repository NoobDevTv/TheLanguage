using Arrow.Core.Basekeywords;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arrow.Core.Basemembers
{
    public abstract class FieldDeclarationBase : Member
    {
        public IdentifierKeyword Identifier { get; set; }
        public TypeKeyword Type { get; set; }
    }
}

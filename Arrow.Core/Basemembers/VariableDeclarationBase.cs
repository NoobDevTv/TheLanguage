using Arrow.Core.Basekeywords;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arrow.Core.Basemembers
{
    public abstract class VariableDeclarationBase : Member
    {
        public IdentifierKeyword Identifier { get; set; }
        public TypeKeyword Type { get; set; }

        public bool IsParameter { get; set; }
    }
}

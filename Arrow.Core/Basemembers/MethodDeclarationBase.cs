using Arrow.Core.Basekeywords;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arrow.Core.Basemembers
{
    public abstract class MethodDeclarationBase : Member
    {
        public IdentifierKeyword Identifier { get; private set; }
        public TypeKeyword DeclarationSyntax { get; private set; }
        public BlockBase Body { get; private set; }
        public MemberListBase Signature { get; private set; }
    }
}

using Arrow.Core.Basekeywords;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arrow.Core.Basemembers
{
    public abstract class MethodDeclarationBase : Member
    {
        public IdentifierKeyword Identifier { get; protected set; }
        public TypeKeyword DeclarationSyntax { get; protected set; }
        public BlockBase Body { get; protected set; }
        public MemberListBase Signature { get; protected set; }
    }
}

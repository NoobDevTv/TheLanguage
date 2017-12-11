using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Core.Parsing
{
    public enum SyntaxDefinitionType
    {
        Identifier,
        Integer,
        Operation,
        Parent,
        Variable,
        Return,
        Statement,
        Scope,
        Primitive,
        TypeDeclaration,
        MethodDeclaration
    }
}

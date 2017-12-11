using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arrow.Core.Parsing;
using Arrow.Core.Parsing.Definition;

namespace Arrow.Core.Visitors
{
    class ProgramVisitor : Visitor<ProgramScope>
    {
        public void Visit(ClassDeclarationSyntax syntax, ProgramScope scope)
        {
            base.Visit(syntax, scope);
        }
    }
}

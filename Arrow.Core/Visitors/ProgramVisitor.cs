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
            var type = scope.ModuleBuilder.DefineType(syntax.Identifier.Name);

            if (syntax.Body != null)
            {

                var classVisitor = new ClassVisitor();
                var classScope = new ClassScope(type);
                classVisitor.Visit(syntax.Body, classScope);
            }

            type.CreateType();
            
        }
    }
}

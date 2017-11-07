using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arrow.Core.Parsing.Definition;

namespace Arrow.Core.Visitors
{
    class ClassVisitor : Visitor<ClassScope>
    {
        public void Visit(MethodDeclarationSyntax syntax, ClassScope scope)
        {
            MethodeScope methodeScope = new MethodeScope()
            {
                ReturnType = null,
                Name = syntax.Identifier.Name,
            };

            var methodeBuilder = scope.TypeBuilder.DefineMethod(methodeScope.Name, 
                System.Reflection.MethodAttributes.Public, null, null);

            methodeScope.BodyScope = new CodeScope(methodeBuilder.GetILGenerator());

            CodeVisitor codeVisitor = new CodeVisitor();
            codeVisitor.Visit(syntax.Body, methodeScope.BodyScope);
        }
    }
}

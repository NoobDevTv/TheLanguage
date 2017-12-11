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
            var parameterTypes = syntax.Signature?.Parameters.Select(p => p.TypeDeclaration.TypeSyntax.Type).ToArray();

            MethodeScope methodeScope = new MethodeScope()
            {
                ReturnType = syntax.DeclarationSyntax.TypeSyntax.Type,
                ParameterTypes = parameterTypes,
                Name = syntax.Identifier.Name,
            };

            var methodeBuilder = scope.TypeBuilder.DefineMethod(methodeScope.Name,
                System.Reflection.MethodAttributes.Public, methodeScope.ReturnType, methodeScope.ParameterTypes);

            methodeScope.BodyScope = new CodeScope(methodeScope, methodeBuilder.GetILGenerator());



            int i = 1;

            if (syntax.Signature != null)
            {
                foreach (var parameter in syntax.Signature.Parameters)
                {
                    var parameterBuilder = methodeBuilder.DefineParameter(
                        i++, System.Reflection.ParameterAttributes.None, parameter.Name);
                    methodeScope.BodyScope.ParameterVariables.Add(parameter.Name, parameterBuilder);

                }
            }

            CodeVisitor codeVisitor = new CodeVisitor();
            codeVisitor.Visit(syntax.Body, methodeScope.BodyScope);
        }
    }
}

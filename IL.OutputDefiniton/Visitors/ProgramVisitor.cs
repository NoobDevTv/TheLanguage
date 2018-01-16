using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IL.OutputDefinition.Visitors
{
    class ProgramVisitor : Visitor<ProgramScope>
    {
        public void Visit(NamespaceDeclarationSyntax syntax, ProgramScope scope)
        {
            foreach (var member in syntax.MemberList)
            {
                Visit(member, scope);
            }
        }

        public void Visit(ClassDeclarationSyntax syntax, ProgramScope scope)
        {
            var type = scope.ModuleBuilder.DefineType(syntax.Identifier.Name, System.Reflection.TypeAttributes.Public);

            if (syntax.BaseClass != null)
            {
                var typename = syntax.BaseClass.TypeIdentifier;

                Type parentType;
                if (!scope.Types.TryGetValue(typename, out parentType))
                {
                    throw new Exception($"{typename} not found");
                }

                type.SetParent(parentType);
            }

            scope.Types.Add(syntax.Identifier.Name, type);

            if (syntax.Body != null)
            {

                var classVisitor = new ClassVisitor();
                var classScope = new ClassScope(type);
                classVisitor.Visit(syntax.Body, classScope);
            }

            type.CreateType();

        }

        public void Visit(MethodDeclarationSyntax syntax, ProgramScope scope)
        {

            var parameterTypes = syntax.Signature?.Parameters.Select(p => p.TypeDeclaration.TypeSyntax.Type).ToArray();

            MethodeScope methodeScope = new MethodeScope()
            {
                ReturnType = syntax.DeclarationSyntax.TypeSyntax.Type,
                ParameterTypes = parameterTypes,
                Name = syntax.Identifier.Name,
            };

            var methodeBuilder = scope.ModuleBuilder.DefineGlobalMethod(syntax.Identifier.Name,
                System.Reflection.MethodAttributes.Static, methodeScope.ReturnType, methodeScope.ParameterTypes);

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

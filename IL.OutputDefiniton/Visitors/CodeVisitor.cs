using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace IL.OutputDefinition.Visitors
{
    class CodeVisitor : Visitor<CodeScope>
    {
        public void Visit(IdentifierSyntax syntax, CodeScope scope)
        {
            Console.WriteLine(syntax.Name);

            if (scope.LocalVariables.TryGetValue(syntax.Name,out var variable))
            {
                scope.Generator.Emit(OpCodes.Ldloc, variable);
            }
            else if (scope.ParameterVariables.TryGetValue(syntax.Name, out var parameter))
            {
                switch (parameter.Position)
                {
                    case 1:
                        scope.Generator.Emit(OpCodes.Ldarg_1);
                        break;
                    case 2:
                        scope.Generator.Emit(OpCodes.Ldarg_2);
                        break;
                    case 3:
                        scope.Generator.Emit(OpCodes.Ldarg_3);
                        break;
                    default:
                        scope.Generator.Emit(OpCodes.Ldarg_S, parameter.Position);
                        break;
                }
                
            }
            else
            {
                throw new Exception("No Variable found");
            }

            
        }

        public void Visit(IntegerSyntax syntax, CodeScope scope)
        {
            Console.WriteLine(syntax.Value);
            scope.Generator.Emit(OpCodes.Ldc_I4, syntax.Value);
        }

        public void Visit(OperationSyntax syntax, CodeScope scope)
        {
            Visit(syntax.Left,scope);
            Visit(syntax.Right,scope);

            switch (syntax.Operation)
            {
                case OperationKind.Divisor:
                    scope.Generator.Emit(OpCodes.Div);
                    break;
                case OperationKind.Modulo:

                    break;
                case OperationKind.Point:
                    scope.Generator.Emit(OpCodes.Mul);
                    break;
                case OperationKind.Minus:
                    scope.Generator.Emit(OpCodes.Sub);
                    break;
                case OperationKind.Plus:
                    scope.Generator.Emit(OpCodes.Add);
                    break;
                default:
                    break;
            }



            Console.WriteLine(syntax.Operation);
        }

        public void Visit(ParentSyntax syntax, CodeScope scope)
        {
            Visit(syntax.Member,scope);
        }

        public void Visit(ReturnSyntax syntax, CodeScope scope)
        {
            Visit(syntax.Expression, scope);
            scope.Generator.Emit(OpCodes.Ret);
        }

        public void Visit(StatmentSyntax syntax, CodeScope scope)
        {
            foreach (var statment in syntax.Statments)
            {
                Visit(statment,scope);
            }
        }

        public void Visit(TokenSyntax syntax, CodeScope scope)
        {
            throw new NotImplementedException();
        }

        public void Visit(VariableDeclarationSyntax syntax, CodeScope scope)
        {
            Console.WriteLine(syntax.Name);

            var variable = scope.Generator.DeclareLocal(typeof(int));
            //variable.SetLocalSymInfo(Name);

            scope.LocalVariables[syntax.Name] = variable;

            if (syntax.Expression != null)
            {
                Visit(syntax.Expression,scope);
                scope.Generator.Emit(OpCodes.Stloc, variable);

                Console.WriteLine("Sto");
            }
        }

        public void Visit(ScopeSyntax scopeSyntax, CodeScope scope)
        {
            if (scopeSyntax.Members == null || scopeSyntax.Members.Count == 0)
            {
                scope.Generator.Emit(OpCodes.Nop);
                return;
            }

            foreach (var member in scopeSyntax.Members)
            {
                Visit(member, scope);
            }
            
        }
    }
}

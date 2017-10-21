using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler.Parsing.Definition;
using System.Reflection.Emit;
using static Compiler.Parsing.Definition.OperationSyntax;

namespace Compiler.Visitors
{
    class CodeVisitor : Visitor
    {
        public override void Visit(IdentifierSyntax syntax, Scope scope)
        {
            Console.WriteLine(syntax.Name);

            var variable = scope.LocalVariables[syntax.Name];
            scope.Generator.Emit(OpCodes.Ldloc, variable);
        }

        public override void Visit(IntegerSyntax syntax, Scope scope)
        {
            Console.WriteLine(syntax.Value);
            scope.Generator.Emit(OpCodes.Ldc_I4, syntax.Value);
        }

        public override void Visit(OperationSyntax syntax, Scope scope)
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

        public override void Visit(ParentSyntax syntax, Scope scope)
        {
            Visit(syntax.Member,scope);
        }

        public override void Visit(ReturnSyntax syntax, Scope scope)
        {
            Visit(syntax.Expression, scope);
            scope.Generator.Emit(OpCodes.Ret);
        }

        public override void Visit(StatmentSyntax syntax, Scope scope)
        {
            foreach (var statment in syntax.Statments)
            {
                Visit(statment,scope);
            }
        }

        public override void Visit(TokenSyntax syntax, Scope scope)
        {
            throw new NotImplementedException();
        }

        public override void Visit(VariableDeclerationSyntax syntax, Scope scope)
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
    }
}

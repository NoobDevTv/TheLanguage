using Compiler.Parsing;
using Compiler.Parsing.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Visting
{
    public class Visitor
    {
        public Func<int> Compile(Syntax syntax)
        {
            DynamicMethod methode = new DynamicMethod("Test", typeof(int), null);

            var generator = methode.GetILGenerator();
            Visit(syntax, generator);

            generator.Emit(OpCodes.Ret);

            return (Func<int>)methode.CreateDelegate(typeof(Func<int>));
        }

        public void Visit(Syntax syntax, ILGenerator generator)
        {
            switch (syntax)
            {
                case AdditionSyntax addSyntax:
                    Visit(addSyntax,generator);
                    break;
                case SubstractionSyntax subSyntax:
                    Visit(subSyntax, generator);
                    break;
                case IntegerSyntax intSyntax:
                    Visit(intSyntax, generator);
                    break;
                case ExpressionSyntax expSyntax:
                    Visit(expSyntax, generator);
                    break;
                default:
                    break;
            }
        }

        public void Visit(AdditionSyntax syntax,ILGenerator generator)
        {
            Visit(syntax.Left, generator);
            Visit(syntax.Right, generator);
            generator.Emit(OpCodes.Add);
            Console.WriteLine("Add");
        }

        public void Visit(SubstractionSyntax syntax, ILGenerator generator)
        {
            Visit(syntax.Left,generator);
            Visit(syntax.Right, generator);
            generator.Emit(OpCodes.Sub);
            Console.WriteLine("Sub");

        }

        public void Visit(ExpressionSyntax syntax, ILGenerator generator)
        {
            Visit(syntax.Expression,generator);
        }

        public void Visit(IntegerSyntax syntax, ILGenerator generator)
        {
            generator.Emit(OpCodes.Ldc_I4, syntax.Value);
            Console.WriteLine(syntax.Value);
        }
    }
}

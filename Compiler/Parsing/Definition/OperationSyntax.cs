using Compiler.Scanning;
using Compiler.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Parsing.Definition
{
    [Syntax(10)]
    public class OperationSyntax : Syntax
    {
        public Syntax Left { get; private set; }
        public Syntax Right { get; private set; }
        public OperationKind Operation { get; set; }

        public OperationSyntax() : base(nameof(OperationSyntax))
        {
        }

        public override bool TryParse(SyntaxStream stream, Scanner scanner)
        {

            if (stream.Count < 3)
                return false;

            foreach (var operation in Enum.GetNames(typeof(OperationKind)).Reverse())
            {
                int openBracket = 0;

                for (int i = 0; i < stream.Count - 1; i++)
                {
                    if (stream[i].Name == "BracketOpen")
                        openBracket++;
                    else if (stream[i].Name == "BracketClose")
                        openBracket--;
                    else if (stream[i].Name == operation &&
                             openBracket == 0)
                    {
                        Left = scanner.Scan(stream.Take(i));
                        Right = scanner.Scan(stream.Skip(i + 1));
                        Operation = (OperationKind)Enum.Parse(typeof(OperationKind), operation);
                        return true;
                    }
                }
            }

            return false;
        }

        public override void Visit(Scope scope)
        {
            Left.Visit(scope);
            Right.Visit(scope);

            switch (Operation)
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

            

            Console.WriteLine(Operation);
        }

        public enum OperationKind
        {
            Divisor,
            Modulo,
            Point,
            Minus,
            Plus
        }
    }
}

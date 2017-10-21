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

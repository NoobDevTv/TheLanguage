using Arrow.Core.Basestatements;
using Arrow.Core.Scanning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Definition.Statements
{
    public class Operation : OperationStatement
    {
        

        public Operation() : base(nameof(Statements.Operation))
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
                        Position = stream.GlobalPosition;
                        Length = 1 + Left.Length + Right.Length;
                        return true;
                    }
                }
            }

            return false;
        }
    }
}

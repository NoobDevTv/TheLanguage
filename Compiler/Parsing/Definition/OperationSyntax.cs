using Compiler.Scanning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Parsing.Definition
{
    public class OperationSyntax : Syntax
    {
        public Syntax Left { get; private set; }
        public Syntax Right { get; private set; }
        public string TokenName { get; }
        public OperationKind Operation { get; set; }

        public OperationSyntax(string name, string tokenName) : base(name)
        {
            TokenName = tokenName;
        }
        private OperationSyntax(OperationSyntax operationSyntax) : this(operationSyntax.Name, operationSyntax.TokenName)
        {

        }

        public override bool TryParse(SyntaxStream stream, Scanner scanner, out Syntax syntax)
        {
            syntax = null;

            if (stream.Count < 3)
                return false;

            foreach (var operation in Enum.GetNames(typeof(OperationKind)))
            {
                for (int i = 1; i < stream.Count - 1; i++)
                {
                    if (stream[i].Name == operation)
                    {
                        Left = scanner.Scan(stream.Take(i));
                        Right = scanner.Scan(stream.Skip(i + 1));
                        Operation = (OperationKind)Enum.Parse(typeof(OperationKind), operation);
                        syntax = new OperationSyntax(this);
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

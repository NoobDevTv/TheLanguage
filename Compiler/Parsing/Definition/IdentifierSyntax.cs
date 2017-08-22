using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler.Visitors;
using System.Reflection.Emit;

namespace Compiler.Parsing.Definition
{
    [Syntax(0)]
    public class IdentifierSyntax : Syntax
    {
        public IdentifierSyntax() : base(nameof(IdentifierSyntax))
        {
        }

        public string Name { get; private set; }

        public override bool TryParse(SyntaxStream stream, Scanner scanner)
        {

            if (stream.Count != 1)
                return false;

            if (stream[0] is TokenSyntax tokenSyntax)
            {
                if (tokenSyntax.Name == "Identifier")
                {
                    Name =tokenSyntax.Token.Value;
                    return true;
                }
            }

            return false;
        }

        public override void Visit(Scope scope)
        {
            Console.WriteLine(Name);

            var variable = scope.LocalVariables[Name];
            scope.Generator.Emit(OpCodes.Ldloc,variable);

        }
    }
}

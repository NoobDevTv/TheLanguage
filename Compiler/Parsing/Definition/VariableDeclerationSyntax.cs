using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler.Visitors;
using System.Reflection.Emit;

namespace Compiler.Parsing.Definition
{
    [Syntax(30)]
    public class VariableDeclerationSyntax : Syntax
    {
        public VariableDeclerationSyntax() : base(nameof(VariableDeclerationSyntax))
        {
        }

        public string Name { get; private set; }
        public Syntax Expression { get; private set; }

        public override bool TryParse(SyntaxStream stream, Scanner scanner)
        {
            var result = false;

            if (stream[0].Name == "Var" && stream[1].Name == "Identifier")
            {
                var identifierToken = (TokenSyntax)stream[1];
                Name = identifierToken.Token.Value;

                result = true;
            }

            if ( stream.Count > 2 &&stream[2].Name == "AssignEquals")
            {
                Expression = scanner.Scan(stream.Skip(3));
            }

            return result;
        }

        public override void Visit(Scope scope)
        {
            Console.WriteLine(Name);

            var variable = scope.Generator.DeclareLocal(typeof(int));
            //variable.SetLocalSymInfo(Name);

            scope.LocalVariables[Name] = variable;

            if (Expression != null)
            {
                Expression.Visit(scope);
                scope.Generator.Emit(OpCodes.Stloc, variable);

                Console.WriteLine("Sto");
            }
        }
    }
}

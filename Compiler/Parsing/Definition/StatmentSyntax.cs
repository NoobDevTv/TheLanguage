using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler.Visitors;

namespace Compiler.Parsing.Definition
{
    [Syntax(30)]
    public class StatmentSyntax : Syntax
    {
        public Syntax Statment { get; private set; }


        public StatmentSyntax() : base(nameof(StatmentSyntax))
        {

        }

        public override bool TryParse(SyntaxStream stream, Scanner scanner)
        {
            for (int i = 0; i < stream.Count; i++)
            {
                if(stream[i].Name == "CodeLineEnd")
                {
                    Statment = scanner.Scan(stream.Take(i));
                    return true;
                }
            }

            return false;
        }

        public override void Visit(Scope scope)
        {
            Statment.Visit(scope);
        }
    }
}

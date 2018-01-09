using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arrow.Core.Visitors;

namespace Arrow.Core.Parsing.Definition
{
    [Syntax(SyntaxDefinitionType.Statement)]
    public class StatmentSyntax : Syntax
    {
        public List<Syntax> Statments { get; private set; }


        public StatmentSyntax() : base(nameof(StatmentSyntax))
        {
            Statments = new List<Syntax>();
        }

        public override bool TryParse(SyntaxStream stream, Scanner scanner)
        {
            //TODO: need a new Implementation
            var lastPosition = 0;
            var result = false;

            for (int i = 0; i < stream.Count; i++)
            {
                if (stream[i].Name == "CodeLineEnd")
                {
                    Statments.Add(scanner.Scan(stream.Get(lastPosition, i - lastPosition)));
                    lastPosition = i + 1;
                    result = true;
                }
            }

            Position = stream.GlobalPosition;
            Length = stream.Count;

            return result;
        }
    }
}

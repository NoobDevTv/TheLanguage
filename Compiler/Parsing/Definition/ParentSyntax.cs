using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Parsing.Definition
{
    public class ParentSyntax : Syntax
    {
        public Syntax Open { get; private set; }
        public Syntax Close { get; private set; }
        public Syntax Member { get; private set; }

        public ParentSyntax(string name) : base(name)
        {
        }

        public override bool TryParse(SyntaxStream stream, Scanner scanner, out Syntax syntax)
        {
            syntax = null;

            if (!(stream[0].Name == "BracketOpen") &&
                !(stream[stream.Count - 1].Name == "BracketClose"))
                return false;

            Open = stream[0];
            Close = stream[stream.Count - 1];

            syntax = this;

            Member = scanner.Scan(stream.Get(1, stream.Count - 2));

            return true;
        }
    }
}

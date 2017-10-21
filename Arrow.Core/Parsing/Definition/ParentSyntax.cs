using Arrow.Core.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Core.Parsing.Definition
{
    [Syntax(30)]
    public class ParentSyntax : Syntax
    {
        public Syntax Open { get; private set; }
        public Syntax Close { get; private set; }
        public Syntax Member { get; private set; }

        protected string nameOpen;
        protected string nameClose;

        public ParentSyntax() : base(nameof(ParentSyntax))
        {
            nameOpen = "BracketOpen";
            nameClose = "BracketClose";
        }

        public override bool TryParse(SyntaxStream stream, Scanner scanner)
        {

            if (stream[0].Name != nameOpen ||
                stream[stream.Count - 1].Name != nameClose)
                return false;

            int openCount = 1;

            for (int i = 1; i < stream.Count; i++)
            {
                if (stream[i].Name == nameOpen)
                    openCount++;

                else if (stream[i].Name == nameClose)
                {
                    openCount--;

                    if (openCount == 0 && i != stream.Count - 1)
                    {
                        return false;
                    }

                    if (openCount == 0 &&
                        i == stream.Count - 1)
                    {
                        Open = stream[0];
                        Close = stream[i];

                        Member = scanner.Scan(stream.Get(1, i - 1));

                        return true;
                    }
                }
            }

            return false;
        }
    }
}

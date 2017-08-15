using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Parsing.Definition
{
    [Syntax(20)]
    public class ParentSyntax : Syntax
    {
        public Syntax Open { get; private set; }
        public Syntax Close { get; private set; }
        public Syntax Member { get; private set; }

        public ParentSyntax() : base(nameof(ParentSyntax))
        {
        }
        //(a*(b * b)) * (c + g) +2 
        public override bool TryParse(SyntaxStream stream, Scanner scanner)
        {
            
            if (stream[0].Name != "BracketOpen" ||
                stream[stream.Count - 1].Name != "BracketClose")
                return false;

            int openCount = 1;

            for (int i = 1; i < stream.Count; i++)
            {
                if (stream[i].Name == "BracketOpen")
                    openCount++;

                else if(stream[i].Name == "BracketClose")
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

                        Member = scanner.Scan(stream.Get(1, i -1));
                        
                        return true;
                    }
                }
            }

            return false;
        }
    }
}

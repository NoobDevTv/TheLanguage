using Arrow.Core;
using Arrow.Core.Basestatements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Definition.Statements
{
    public class Parent : ParentStatement
    {
        private readonly string nameOpen;
        private readonly string nameClose;

        public Parent()
        {
            nameOpen = "BracketOpen";
            nameClose = "BracketClose";
        }

        public override bool TryParse(TokenStream stream, Scanner scanner)
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
                        if (i -1 != 0)
                        {
                            //TODO: TryScan with IExpression
                            Member = scanner.Scan(stream.Get(1, i - 1));
                        }

                        Position = stream.GlobalPosition;
                        Length = i + 1;

                        return true;
                    }
                }
            }

            return false;
        }
    }
}

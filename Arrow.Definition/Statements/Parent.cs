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

                        if (i -1 == 0)
                        {
                            if (!AllowEmpty)
                                throw new Exception("Empty Member");
                        }
                        else
                        {
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

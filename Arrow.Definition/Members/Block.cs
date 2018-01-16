using Arrow.Core.Basemembers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Definition.Members
{
    class Block : BlockBase
    {
      
        public override bool TryParse(SyntaxStream stream, Scanner scanner)
        {
            if (stream[0].Name != nameOpen)
                return false;

            int openCount = 1;

            for (int i = 1; i < stream.Count; i++)
            {
                if (stream[i].Name == nameOpen)
                    openCount++;

                else if (stream[i].Name == nameClose)
                {
                    openCount--;

                    if (openCount == 0)
                    {
                        Open = stream[0];
                        Close = stream[i];

                        if (i - 1 == 0)
                        {
                            if (!AllowEmpty)
                                throw new Exception("Empty Member");
                        }
                        else
                        {
                            Members.AddRange(SearchMember(1, i, stream, scanner));
                        }


                        Count = i + 1;
                        Position = stream.GlobalPosition;
                        Length = i + 1;
                        return true;
                    }
                }
            }

            return false;
        }

        private IEnumerable<Syntax> SearchMember(int start, int end, SyntaxStream stream, Scanner scanner)
        {
            int index = start;

            //TODO:Skip to Get
            while (index < end && scanner.TryScan(stream.Get(index, end - index), out Syntax member))
            {
                index += member.Length;
                yield return member;

                if (index > end)
                {
                    break;
                }
            }
        }
    }
}

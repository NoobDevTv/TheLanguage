using Arrow.Core.Basemembers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Definition.Members
{
    public class ParameterList : MemberListBase
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
                            SearchParameter(1, i, stream, scanner);
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

        private void SearchParameter(int start, int end, SyntaxStream stream, Scanner scanner)
        {
            int index = start;
            var tmpList = new List<ParameterDeclaration>();

            for (int i = start; i <= end; i++)
            {
                var token = stream[i];
                if (token.Name == "Comma" || i == end)
                {
                    if (scanner.TryScan(stream.Get(index, i - index), out ParameterDeclaration parameter))
                    {
                        tmpList.Add(parameter);
                    }
                    else
                    {
                        throw new Exception("Wrong Parameter declaration");
                    }

                    index = i + 1;
                }
            }

            Parameters = tmpList;
        }
    }
}

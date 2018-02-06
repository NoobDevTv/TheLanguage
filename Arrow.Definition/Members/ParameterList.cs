using Arrow.Core;
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
        private readonly string nameOpen;
        private readonly string nameClose;

        public ParameterList()
        {
            nameOpen = "BracketOpen";
            nameClose = "BracketClose";
        }

        public override bool TryParse(TokenStream stream, Scanner scanner)
        {
            if (stream.Count < 2)
                return false;

            if (stream[0].Name != nameOpen)
                return false;

            int openCount = 1;

            for (int i = 1; i < stream.Count; i++)
            {
                if (stream[i].Name == nameOpen)
                {
                    openCount++;
                }
                else if (stream[i].Name == nameClose)
                {
                    openCount--;

                    if (openCount == 0)
                    {
                        Members.AddRange(SearchParameter(1, i, stream, scanner));

                        Position = stream.GlobalPosition;
                        Length = i + 1;

                        return true;
                    }
                }
            }

            return false;
        }

        private List<ParameterDeclaration> SearchParameter(int start, int end, TokenStream stream, Scanner scanner)
        {
            int index = start;
            var tmpList = new List<ParameterDeclaration>();

            if (end <= 1)
                return tmpList;

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

            return tmpList;
        }
    }
}

using Arrow.Core.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Core.Parsing.Definition
{
    public class ParameterListSyntax : Syntax
    {
        public Syntax Open { get; private set; }
        public Syntax Close { get; private set; }

        public List<ParameterDeclarationSyntax> Parameters { get; private set; }

        public int Length { get; set; }

        public bool AllowEmpty { get; protected set; }

        protected string nameOpen;
        protected string nameClose;

        public ParameterListSyntax() : base(nameof(ParameterListSyntax))
        {
            nameOpen = "BracketOpen";
            nameClose = "BracketClose";
            AllowEmpty = true;
            Parameters = new List<ParameterDeclarationSyntax>();
        }

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
            var tmpList = new List<ParameterDeclarationSyntax>();

            for (int i = start; i <= end; i++)
            {
                var token = stream[i];
                if (token.Name == "Comma" || i == end)
                {
                    if (scanner.TryScan(stream.Get(index, i - index), out ParameterDeclarationSyntax parameter))
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

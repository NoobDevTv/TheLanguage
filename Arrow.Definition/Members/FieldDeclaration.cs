using Arrow.Core.Basemembers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Definition.Members
{
    public class FieldDeclaration : FieldDeclarationBase
    {

        public override bool TryParse(SyntaxStream stream, Scanner scanner)
        {
            for (int i = 0; i < stream.Count; i++)
            {
                if (stream[i].Name == "CodeLineEnd")
                {
                    var result = base.TryParse(stream.Take(i), scanner);
                    Length += 1;
                    return result;
                }
            }

            return false;
            
        }
    }
}

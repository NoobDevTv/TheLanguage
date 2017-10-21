using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Core.Parsing
{
    interface IScanable
    {
        bool TryParse(SyntaxStream stream, Scanner scanner);
    }
}

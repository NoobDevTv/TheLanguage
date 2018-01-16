using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IL.OutputDefinition.Visitors
{
    public class MethodeScope : Scope
    {
        public string Name { get; set; }

        public Type ReturnType { get; set; }

        public Type[] ParameterTypes { get; set; }

        public CodeScope BodyScope { get; set; }
    }
}

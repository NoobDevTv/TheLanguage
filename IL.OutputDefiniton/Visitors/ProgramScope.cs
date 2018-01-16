using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace IL.OutputDefinition.Visitors
{
    class ProgramScope : Scope
    {
        public ModuleBuilder ModuleBuilder { get; private set; }

        public Dictionary<string,Type> Types { get; }

        public ProgramScope(ModuleBuilder moduleBuilder)
        {
            Types = new Dictionary<string, Type>();

            ModuleBuilder = moduleBuilder;
        }
    }
}

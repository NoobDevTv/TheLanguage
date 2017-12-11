using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Core.Visitors
{
    class ProgramScope : Scope
    {
        public ModuleBuilder ModuleBuilder { get; private set; }

        public ProgramScope(ModuleBuilder moduleBuilder)
        {
            ModuleBuilder = moduleBuilder;
        }
    }
}

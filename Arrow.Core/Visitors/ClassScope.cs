using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Core.Visitors
{
    public class ClassScope : Scope
    {
        public readonly TypeBuilder TypeBuilder;

        public Dictionary<string,FieldBuilder> Fields;

        public ClassScope(TypeBuilder typeBuilder)
        {
            Fields = new Dictionary<string, FieldBuilder>();
            TypeBuilder = typeBuilder;
        }
    }
}

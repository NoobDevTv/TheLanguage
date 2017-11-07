using Arrow.Core.Parsing;
using Arrow.Core.Parsing.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Core.Visitors
{
    internal abstract class Visitor<C>
        where C : Scope
    {
        private Dictionary<Type, MethodInfo> methods;

        public Visitor()
        {
            methods = new Dictionary<Type, MethodInfo>();
        }

        public virtual void Visit(Syntax syntax, C scope)
        {
            MethodInfo method;
            if (!methods.TryGetValue(syntax.GetType(), out method))
                method = GetType().GetMethods().FirstOrDefault(v =>
                             v.GetParameters().FirstOrDefault(
                                  p => p.ParameterType == syntax.GetType()) != null);

            method.Invoke(this, new object[] { syntax, scope });
        }
    }
}

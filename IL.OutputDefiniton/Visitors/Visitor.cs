using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IL.OutputDefinition.Visitors
{
    internal abstract class Visitor<C>
        where C : Scope
    {
        private Dictionary<Type, MethodInfo> methods;

        public Visitor()
        {
            methods = new Dictionary<Type, MethodInfo>();
        }

        public virtual void Visit(object syntax, C scope) //TODO Temp: Syntax as base type
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

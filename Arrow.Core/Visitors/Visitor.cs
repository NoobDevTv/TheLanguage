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
    internal abstract class Visitor
    {
        private Dictionary<Type, MethodInfo> methods;

        public Visitor()
        {
            methods = new Dictionary<Type, MethodInfo>();
        }

        public virtual void Visit(Syntax syntax, Scope scope)
        {
            MethodInfo method;
            if (!methods.TryGetValue(syntax.GetType(), out method))
                method = GetType().GetMethods().FirstOrDefault(v =>
                             v.GetParameters().FirstOrDefault(
                                  p => p.ParameterType == syntax.GetType()) != null);

            method.Invoke(this, new object[] { syntax, scope });
        }

        public abstract void Visit(IdentifierSyntax syntax, Scope scope);

        public abstract void Visit(IntegerSyntax syntax, Scope scope);

        public abstract void Visit(OperationSyntax syntax, Scope scope);

        public abstract void Visit(ParentSyntax syntax, Scope scope);

        public abstract void Visit(ReturnSyntax syntax, Scope scope);

        public abstract void Visit(StatmentSyntax syntax, Scope scope);

        public abstract void Visit(TokenSyntax syntax, Scope scope);

        public abstract void Visit(VariableDeclerationSyntax syntax, Scope scope);
    }
}

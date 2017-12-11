using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Core.Visitors
{
    public class CodeScope : Scope
    {

        public Dictionary<string, LocalBuilder> LocalVariables { get; }
        public Dictionary<string, ParameterBuilder> ParameterVariables { get; }
        public MethodeScope ParentScope { get; }
        public ILGenerator Generator { get; }

        public DynamicMethod Methode { get; protected set; }


        private CodeScope()
        {
            LocalVariables = new Dictionary<string, LocalBuilder>();
            ParameterVariables = new Dictionary<string, ParameterBuilder>();
        }
        public CodeScope(MethodeScope methodeScope, ILGenerator generator) : this()
        {
            ParentScope = methodeScope;
            Generator = generator;
        }
        public CodeScope(string name, Type returnType) : this()
        {
            Methode = new DynamicMethod(name, returnType, null);
            Generator = Methode.GetILGenerator();
        }

        public Func<T> GetMethode<T>()
        {
            return (Func<T>)Methode.CreateDelegate(typeof(Func<T>));
        }

        public Action GetMethode()
        {
            return (Action)Methode.CreateDelegate(typeof(Action));
        }
    }
}

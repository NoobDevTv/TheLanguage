using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Core.Visitors
{
    public class Scope
    {

        public Dictionary<string,LocalBuilder> LocalVariables { get; }

        public ILGenerator Generator { get; }

        public  DynamicMethod Methode { get; protected set; }

        public Scope(string name,Type returnType)
        {
            Methode = new DynamicMethod(name, returnType, null);
            Generator = Methode.GetILGenerator();

            LocalVariables = new Dictionary<string, LocalBuilder>();

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

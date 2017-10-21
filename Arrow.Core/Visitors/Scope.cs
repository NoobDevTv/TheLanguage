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

        public Scope()
        {
            Methode = new DynamicMethod("Test", typeof(int), null);
            Generator = Methode.GetILGenerator();

            LocalVariables = new Dictionary<string, LocalBuilder>();

        }

        public Func<int> GetMethode()
        {
            return (Func<int>)Methode.CreateDelegate(typeof(Func<int>));
        }
    }
}

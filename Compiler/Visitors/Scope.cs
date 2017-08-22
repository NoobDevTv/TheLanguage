using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Visitors
{
    public class Scope
    {
        public ILGenerator Generator { get; }

        private DynamicMethod methode;

        public Scope()
        {
            methode = new DynamicMethod("Test", typeof(int), null);
            Generator = methode.GetILGenerator();
        }

        public Func<int> GetMethode()
        {
            return (Func<int>)methode.CreateDelegate(typeof(Func<int>));
        }
    }
}

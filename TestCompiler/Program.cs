using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace TestCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            //1+1
            DynamicMethod dm = new DynamicMethod("Test", typeof(int), null);
            var generator = dm.GetILGenerator();

            generator.Emit(OpCodes.Ldc_I4, 1);
            generator.Emit(OpCodes.Ldc_I4, 1);
            generator.Emit(OpCodes.Add);
            generator.Emit(OpCodes.Ret);

            

            var methode = (Func<int>)dm.CreateDelegate(typeof(Func<int>));

            Console.WriteLine(methode());
            Console.ReadLine();
        }
    }
}

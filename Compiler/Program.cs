using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace Compiler
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicMethod method = new DynamicMethod("Test", typeof(int), null);
            var ilGenerator = method.GetILGenerator();

            // return 1+4;

            ilGenerator.Emit(OpCodes.Ldc_I4, 1);
            ilGenerator.Emit(OpCodes.Ldc_I4, 4);
            ilGenerator.Emit(OpCodes.Add);
            ilGenerator.Emit(OpCodes.Ret);


            var func = (Func<int>)method.CreateDelegate(typeof(Func<int>));
            Console.WriteLine(func());
            Console.ReadLine();
        }
    }
}

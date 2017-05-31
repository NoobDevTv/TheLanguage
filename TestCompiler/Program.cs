using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using System.Text.RegularExpressions;

namespace TestCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = "13456 + 1"; // 1+1

            Regex integer = new Regex("[0-9]+");

            int a = 1 + 1;
            

            for (int i = 0; i < test.Length;)
            {
                var result = integer.Match(test,i);
                if (!result.Success || i != result.Index)
                    throw new Exception();
                i += result.Length;
            }
           



            Console.ReadLine();
        }
    }
}

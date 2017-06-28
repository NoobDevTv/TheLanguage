using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoslynTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = CSharpSyntaxTree.ParseText(@"using System;
                                                    using System.Collections;
                                                    using System.Linq;
                                                    using System.Text;

                                                    namespace HelloWorld
                                                    {
                                                        class Program
                                                        {
                                                            static void Main(string[] args)
                                                            {
                                                                Console.WriteLine(""Hello, World!"");
                                                                int a = 1 + 2 + 3;
                                                            }
                                                        }
                                                    }");

            var root = (CompilationUnitSyntax)tree.GetRoot();
            var ns = (NamespaceDeclarationSyntax)root.Members[0];
            var clas = (ClassDeclarationSyntax)ns.Members[0];
            var met = (MethodDeclarationSyntax)clas.Members[0];
            var bod = (LocalDeclarationStatementSyntax)met.Body.Statements[1];
            

        }
    }
}

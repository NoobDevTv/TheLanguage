using System;
using System.Collections.Generic;
using System.Text;

namespace IL.OutputDefiniton
{
    class ILGenerator
    {
        public Assembly GetAssembly(string input)
        {
            AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("Test"), AssemblyBuilderAccess.RunAndSave);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule("Test.TestModule", "Test.dll");

            var visitor = new ProgramVisitor();

            var tokenDefinitions = TokenDefinitionCollection.LoadFromIntern();
            var tokenizer = new Tokenizer(tokenDefinitions);
            var tokenResult = tokenizer.Parse(input);
            var scanner = new Scanner();
            var expression = scanner.Scan<NamespaceDeclarationSyntax>(new SyntaxStream(tokenResult));

            visitor.Visit(expression, new ProgramScope(moduleBuilder));

            moduleBuilder.CreateGlobalFunctions();

            assemblyBuilder.Save(@"Test.dll");

            return assemblyBuilder;
        }
    }
}

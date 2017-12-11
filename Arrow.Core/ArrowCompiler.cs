using Arrow.Core.Parsing;
using Arrow.Core.Scanning;
using Arrow.Core.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Core
{
    public class ArrowCompiler
    {
        public Func<T> RunFunc<T>(string input)
        {
            var tokenDefinitions = TokenDefinitionCollection.LoadFromIntern();
            var tokenizer = new Tokenizer(tokenDefinitions);
            var tokenResult = tokenizer.Parse(input);
            var parser = new Parser();
            var synatxTree = parser.Parse(tokenResult);
            return synatxTree.Visit<T>();
        }

        public Action RunVoid(string input)
        {
            var tokenDefinitions = TokenDefinitionCollection.LoadFromIntern();
            var tokenizer = new Tokenizer(tokenDefinitions);
            var tokenResult = tokenizer.Parse(input);
            var parser = new Parser();
            var synatxTree = parser.Parse(tokenResult);
            return synatxTree.Visit();
        }

        public Assembly GetAssembly(string input)
        {
            AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("Test"), AssemblyBuilderAccess.RunAndSave);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule("Test.TestModule", "Test.dll");

            var visitor = new ProgramVisitor();
           
            var tokenDefinitions = TokenDefinitionCollection.LoadFromIntern();
            var tokenizer = new Tokenizer(tokenDefinitions);
            var tokenResult = tokenizer.Parse(input);
            var parser = new Parser();
            var synatxTree = parser.Parse(tokenResult);
            
            visitor.Visit(synatxTree.Expression, new ProgramScope(moduleBuilder));

            moduleBuilder.CreateGlobalFunctions();
                        
            assemblyBuilder.Save(@"Test.dll");

            return assemblyBuilder;
        }
    }
}

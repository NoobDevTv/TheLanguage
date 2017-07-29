using Compiler.Parsing.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Parsing
{
    public delegate bool SyntaxParseDelegate(SyntaxStream stream, Scanner scanner, out Syntax syntax);
    public class Scanner
    {
        Dictionary<int, SyntaxParseDelegate> SyntaxDictionary;

        public Scanner()
        {
            SyntaxDictionary = new Dictionary<int, SyntaxParseDelegate>();

            Collect();
        }


        internal Syntax Scan(SyntaxStream syntaxStream)
        {
            foreach (var syntax in SyntaxDictionary)
            {
                if (syntax.Value(syntaxStream, this, out Syntax returnSyntax))
                    return returnSyntax;

            }


            throw new Exception("No valid Expression found");
        }

        internal void Collect()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => typeof(Syntax).IsAssignableFrom(t));

            foreach (var type in types)
                SyntaxDictionary.Add(SyntaxDictionary.Count + 1, ((Syntax)Activator.CreateInstance(type)).TryParse);
        }
    }
}

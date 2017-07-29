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
        Dictionary<int, Type> SyntaxDictionary;

        public Scanner()
        {
            SyntaxDictionary = new Dictionary<int, Type>();

            Collect();
        }
        
        internal Syntax Scan(SyntaxStream syntaxStream)
        {
            foreach (var syntax in SyntaxDictionary)
            {
                var tmpObject = (Syntax)Activator.CreateInstance(syntax.Value);
                if (tmpObject.TryParse(syntaxStream, this))
                    return tmpObject;
            }


            throw new Exception("No valid Expression found");
        }

        internal void Collect()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => typeof(Syntax).IsAssignableFrom(t));

            foreach (var type in types)
                SyntaxDictionary.Add(SyntaxDictionary.Count + 1, type);
        }
    }
}

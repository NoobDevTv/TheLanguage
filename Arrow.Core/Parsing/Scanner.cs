using Arrow.Core.Parsing.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Core.Parsing
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


        internal bool TryScan(SyntaxStream syntaxStream, out Syntax scanResult)
        {
            scanResult = null;

            foreach (var syntax in SyntaxDictionary)
            {
                scanResult = (Syntax)Activator.CreateInstance(syntax.Value);
                if (scanResult.TryParse(syntaxStream, this))
                    return true;
            }

            return false;
        }
        internal bool TryScan<T>(SyntaxStream syntaxStream, out T scanResult)
            where T : Syntax, new()
        {
            scanResult = new T();
            return scanResult.TryParse(syntaxStream, this);                
        }

        internal Syntax Scan(SyntaxStream syntaxStream)
        {
            if (TryScan(syntaxStream, out var syntax))
                return syntax;

            throw new Exception($"Syntax {syntaxStream.SyntaxList.FirstOrDefault()} not found!");
        }


        internal void Collect()
        {
            //var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetCustomAttributes<SyntaxAttribute>() != null);


            var ass = Assembly.GetExecutingAssembly();

            var types = from type in ass.GetTypes()
                        let attribute = type.GetCustomAttribute<SyntaxAttribute>()
                        where attribute != null
                        orderby attribute.Order descending
                        select type;

            foreach (var type in types)
                SyntaxDictionary.Add(SyntaxDictionary.Count + 1, type);
        }
    }
}

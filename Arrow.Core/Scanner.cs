using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Core
{
    public abstract class Scanner
    {
        Dictionary<int, Type> SyntaxDictionary;

        public Scanner()
        {
            SyntaxDictionary = new Dictionary<int, Type>();
        }


        public bool TryScan(TokenStream syntaxStream, out Syntax scanResult)
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
        public bool TryScan<T>(TokenStream syntaxStream, out T scanResult)
            where T : Syntax, new()
        {
            scanResult = new T();
            return scanResult.TryParse(syntaxStream, this);
        }
    }
}

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

        internal Syntax Scan<T>(SyntaxStream syntaxStream)
            where T : Syntax, new()
        {
            if (TryScan<T>(syntaxStream, out var syntax))
                return syntax;

            throw new Exception($"Syntax {syntaxStream.SyntaxList.FirstOrDefault()} not found!");
        }

    }
}

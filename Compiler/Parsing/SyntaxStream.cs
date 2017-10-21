using Compiler.Parsing.Definition;
using Compiler.Scanning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Parsing
{
    public class SyntaxStream
    {
        public int Count => baseStream != null ? length : syntaxList.Count;
        
        private List<Syntax> syntaxList;
        private SyntaxStream baseStream;
        private int index;
        private int length;

        public Syntax this[int index]
        {
            get
            {
                if (baseStream != null)
                    return baseStream[this.index + index];

                return syntaxList[index];
            }
        }

        public IEnumerable<Syntax> SyntaxList => baseStream == null ? syntaxList : baseStream.SyntaxList.Skip(index).Take(length);

        public SyntaxStream(IEnumerable<Token> tokenList)
        {
            syntaxList = new List<Syntax>();
            syntaxList.AddRange(tokenList.Select(i => new TokenSyntax(i)));
        }
        private SyntaxStream(SyntaxStream syntaxStream, int index, int length)
        {
            baseStream = syntaxStream;
            this.index = index;
            this.length = length;
        }

        public SyntaxStream Skip(int pos)
        {
            return new SyntaxStream(this, pos, Count - pos);
        }

        public SyntaxStream Take(int length)
        {
            return new SyntaxStream(this, 0, length);
        }

        public SyntaxStream Get(int index, int length) => new SyntaxStream(this, index, length);

        public void Replace(Syntax syntax, int start, int length)
        {
            if (baseStream == null)
            {
                syntaxList.RemoveRange(start, length);
                syntaxList.Insert(start, syntax);
            }
            else
            {
                baseStream.Replace(syntax, index + start, length);
                this.length = this.length - length + 1;
            }
        }
    }
}

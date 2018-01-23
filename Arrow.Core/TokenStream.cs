using Arrow.Core.Scanning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Core
{
    public class TokenStream
    {
        public int Count => baseStream != null ? length : tokenList.Count;
        public int GlobalPosition => baseStream == null ? 0 : baseStream.GlobalPosition + index;


        private List<Token> tokenList;
        private TokenStream baseStream;
        private int index;
        private int length;

        public Token this[int index]
        {
            get
            {
                if (baseStream != null)
                    return baseStream[this.index + index];

                return tokenList[index];
            }
        }

        public IEnumerable<Token> SyntaxList => baseStream == null ? tokenList : baseStream.SyntaxList.Skip(index).Take(length);

        public TokenStream(IEnumerable<Token> tokenList)
        {
            this.tokenList = new List<Token>();
            this.tokenList.AddRange(tokenList);
        }
        private TokenStream(TokenStream syntaxStream, int index, int length)
        {
            if (index + length > syntaxStream.Count)
                throw new ArgumentOutOfRangeException(nameof(length));

            baseStream = syntaxStream;
            this.index = index;
            this.length = length;
        }

        public TokenStream Skip(int pos)
        {
            return new TokenStream(this, pos, Count - pos);
        }

        public TokenStream Take(int length)
        {
            return new TokenStream(this, 0, length);
        }

        public TokenStream Get(int index, int length) => new TokenStream(this, index, length);
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Base
{
    public class Tokenizer
    {
        public List<TokenDefinition> Definitions { get;private set; }

        public Tokenizer(List<TokenDefinition> definitions)
        {
            Definitions = definitions;
        }

        public List<Token> Parse(string input)
        {
            var list = new List<Token>();

            for (int i = 0; i < input.Length;)
            {
                bool isSuccess = false;
                
                foreach (var definition in Definitions)
                {
                    var result = definition.Expression.Match(input, i);

                    if (!result.Success)
                        continue;

                    isSuccess = true;

                    i += result.Length;
                    list.Add(new Token(result, definition));
                    break;
                }

                if (!isSuccess)
                    throw new Exception("Invalid expression");
            }
        }
    }
}

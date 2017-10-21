using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Scanning
{
    public class TokenDefinitionCollection : List<TokenDefinition>
    {
        public static TokenDefinitionCollection LoadFromIntern()
        {


            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Compiler.Json.TokenDefinitions.json"))
            {
                using (var textReader = new StreamReader(stream))
                {
                    return JsonConvert.DeserializeObject<TokenDefinitionCollection>(textReader.ReadToEnd());
                }
            }
        }
    }
}

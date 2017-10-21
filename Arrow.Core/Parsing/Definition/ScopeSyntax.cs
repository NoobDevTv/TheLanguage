using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrow.Core.Parsing.Definition
{
    class ScopeSyntax : ParentSyntax
    {
        public ScopeSyntax() : base()
        {
            Name = nameof(ScopeSyntax);
            nameClose = "ScopeEnd";
            nameOpen = "ScopeBegin";
        }
    }
}

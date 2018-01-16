using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Arrow.Core
{
    public abstract class TypeSyntax : Syntax
    {
        public Type Type { get; protected set; }

        protected TypeSyntax(string name) : base(name)
        {
        }
    }
}
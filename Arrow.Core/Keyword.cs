using System;
using System.Collections.Generic;
using System.Text;

namespace Arrow.Core
{
    public abstract class Keyword : Syntax
    {
        public object Value { get; protected set; }
        public Type ValueType { get; protected set; }
    }

    public abstract class Keyword<TValueType> : Keyword
    {
        public new TValueType Value { get => (TValueType)base.Value; set => base.Value = value; }

        public Keyword()
        {
            ValueType = typeof(TValueType);
        }
    }

}

using System;
using System.Collections.Generic;
using System.Text;

namespace Arrow.Core.Basestatements
{
    public abstract class OperationStatement : Statement
    {
        public Syntax Left { get; private set; } //TODO IExpression syntax for better control
        public Syntax Right { get; private set; }
        public OperationKind Operation { get; set; }
    }
}

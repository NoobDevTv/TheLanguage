﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler.Scanning;

namespace Compiler.Parsing.Definition
{
    public class AdditionSyntax : OperationSyntax
    {
        

        public AdditionSyntax() 
            : base(nameof(AdditionSyntax),"Plus")
        {
        }

        
    }
}

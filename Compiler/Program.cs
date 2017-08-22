﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using Compiler.Scanning;
using Compiler.Parsing;

namespace Compiler
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "var alpha = 5; var beta = 6; ret alpha +2 *beta;";



            var tokenDefinitions = new List<TokenDefinition>() {

                new TokenDefinition("CodeLineEnd",";"),
                new TokenDefinition("Return", "ret"),
                new TokenDefinition("Integer", "[0-9]+"),
                new TokenDefinition("Var","var"),
                new TokenDefinition("Identifier","[a-zA-Z][a-zA-Z0-9]+"),
                new TokenDefinition("AssignEquals","[=]"),
                new TokenDefinition("Space", " ", true),
                new TokenDefinition("Minus", "[-]"),
                new TokenDefinition("Plus", "[+]"),
                new TokenDefinition("Point", "[*]"),
                new TokenDefinition("Divisor", "[/]"),
                new TokenDefinition("BracketOpen", "[(]"),
                new TokenDefinition("BracketClose", "[)]")
            };

            Func<int> alpha = () => 5;

            var tokenizer = new Tokenizer(tokenDefinitions);

            var tokenResult = tokenizer.Parse(input);

            var parser = new Parser();

            var synatxTree = parser.Parse(tokenResult);

            var func = synatxTree.Visit();

            Console.WriteLine();
            Console.WriteLine(func());

            Console.ReadLine();
        }
    }
}
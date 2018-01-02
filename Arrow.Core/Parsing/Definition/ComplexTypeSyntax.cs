namespace Arrow.Core.Parsing.Definition
{
    public class ComplexTypeSyntax : TypeSyntax
    {
        public string TypeIdentifier  { get; set; }

        public ComplexTypeSyntax() : base(nameof(ComplexTypeSyntax))
        {
        }

        public override bool TryParse(SyntaxStream stream, Scanner scanner)
        {
            if(stream[0] is TokenSyntax tokenSyntax)
            {
                if(tokenSyntax.Name == "Identifier")
                {
                    TypeIdentifier = tokenSyntax.Token.Value;
                    Position = stream.GlobalPosition;
                    Length = 1;
                    return true;
                }
            }

            return false;
        }
    }
}
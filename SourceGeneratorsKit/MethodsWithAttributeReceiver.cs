namespace SourceGeneratorsKit
{
    using Microsoft.CodeAnalysis;

    public class MethodsWithAttributeReceiver: SyntaxReceiver
    {
        private string expectedAttribute;
        public MethodsWithAttributeReceiver(string expectedAttribute) => this.expectedAttribute = expectedAttribute;

        public override bool CollectMethodSymbol { get; } = true;

        protected override bool ShouldCollectMethodSymbol(IMethodSymbol methodSymbol)
            => methodSymbol.HasAttribute(this.expectedAttribute);
    }
}

namespace SourceGeneratorsKit
{
    using Microsoft.CodeAnalysis;

    public class DerivedClassesReceiver: SyntaxReceiver
    {
        private string baseTypeName;
        public DerivedClassesReceiver(string baseTypeName) => this.baseTypeName = baseTypeName;

        public override bool CollectClassSymbol { get; } = true;

        protected override bool ShouldCollectClassSymbol(INamedTypeSymbol classSymbol)
            => classSymbol.IsDerivedFromType(this.baseTypeName);
    }
}

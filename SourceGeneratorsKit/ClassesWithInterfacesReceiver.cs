namespace SourceGeneratorsKit
{
    using Microsoft.CodeAnalysis;

    public class ClassesWithInterfacesReceiver: SyntaxReceiver
    {
        private string implementedInterface;
        public ClassesWithInterfacesReceiver(string implementedInterface) => this.implementedInterface = implementedInterface;

        public override bool CollectClassSymbol { get; } = true;

        protected override bool ShouldCollectClassSymbol(INamedTypeSymbol classSymbol)
            => classSymbol.IsImplements(this.implementedInterface);
    }
}

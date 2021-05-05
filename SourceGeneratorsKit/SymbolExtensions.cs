namespace SourceGeneratorsKit
{
    using System.Linq;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.Text;

    public static class SymbolExtensions
    {
        public static bool HasAttribute(this ISymbol symbol, string atrributeName)
        {
            return symbol.GetAttributes()
                .Any(_ => _.AttributeClass?.ToDisplayString() == atrributeName);
        }

        public static AttributeData? FindAttribute(this ISymbol symbol, string atrributeName)
        {
            return symbol.GetAttributes()
                .FirstOrDefault(_ => _.AttributeClass?.ToDisplayString() == atrributeName);
        }

        public static bool IsDerivedFromType(this INamedTypeSymbol symbol, string typeName)
        {
            if (symbol.Name == typeName)
            {
                return true;
            }

            if (symbol.BaseType == null)
            {
                return false;
            }

            return symbol.BaseType.IsDerivedFromType(typeName);
        }

        public static bool IsImplements(this INamedTypeSymbol symbol, string typeName)
        {
            return symbol.AllInterfaces.Any(_ => _.ToDisplayString() == typeName);
        }
    }
}

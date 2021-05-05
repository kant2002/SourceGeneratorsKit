Source Generators Toolkit
=========================

Toolkit for writing source generators, and specifically collect important information about project to aid generation itself.

# Getting started

```
[Generator]
public class MagicGenerator : ISourceGenerator
{
    SyntaxReceiver syntaxReceiver = new MethodsWithAttributeReceiver("MagicAttribute");

    /// <inheritdoc/>
    public void Initialize(GeneratorInitializationContext context)
    {
        context.RegisterForSyntaxNotifications(() => syntaxReceiver);
    }

    public void Execute(GeneratorExecutionContext context)
    {
        // Retrieve the populated receiver
        if (!(context.SyntaxContextReceiver is SyntaxReceiver receiver))
        {
            return;
        }

        foreach (IMethodSymbol methodSymbol in this.syntaxReceiver.Methods)
        {
            // process your method here.
        }
    }
}
```

# Find all classes which implements specific interface
```
[Generator]
public class MagicGenerator : ISourceGenerator
{
    SyntaxReceiver syntaxReceiver = new ClassesWithInterfacesReceiver("IEnumerable");

    /// <inheritdoc/>
    public void Initialize(GeneratorInitializationContext context)
    {
        context.RegisterForSyntaxNotifications(() => syntaxReceiver);
    }

    public void Execute(GeneratorExecutionContext context)
    {
        // Retrieve the populated receiver
        if (!(context.SyntaxContextReceiver is SyntaxReceiver receiver))
        {
            return;
        }

        foreach (INamedTypeSymbol classSymbol in this.syntaxReceiver.Classes)
        {
            // process your class here.
        }
    }
}
```

# Find all classes which derived from well-known type
```
[Generator]
public class MagicGenerator : ISourceGenerator
{
    SyntaxReceiver syntaxReceiver = new DerivedClassesReceiver("DbConnection");

    /// <inheritdoc/>
    public void Initialize(GeneratorInitializationContext context)
    {
        context.RegisterForSyntaxNotifications(() => syntaxReceiver);
    }

    public void Execute(GeneratorExecutionContext context)
    {
        // Retrieve the populated receiver
        if (!(context.SyntaxContextReceiver is SyntaxReceiver receiver))
        {
            return;
        }

        foreach (INamedTypeSymbol classSymbol in this.syntaxReceiver.Classes)
        {
            // process your class here.
        }
    }
}
```

# Find all members with given attribute

```
[Generator]
public class MagicGenerator : ISourceGenerator
{
    SyntaxReceiver syntaxReceiver = new MethodsWithAttributeReceiver("MagicAttribute");

    /// <inheritdoc/>
    public void Initialize(GeneratorInitializationContext context)
    {
        context.RegisterForSyntaxNotifications(() => syntaxReceiver);
    }

    public void Execute(GeneratorExecutionContext context)
    {
        // Retrieve the populated receiver
        if (!(context.SyntaxContextReceiver is SyntaxReceiver receiver))
        {
            return;
        }

        foreach (IMethodSymbol methodSymbol in this.syntaxReceiver.Methods)
        {
            // process your method here.
            var parameters = methodSymbol.Parameters;
            foreach (var parameter in parameters)
            {
                // Do your parameter magic here.
            }
        }
    }
}
```
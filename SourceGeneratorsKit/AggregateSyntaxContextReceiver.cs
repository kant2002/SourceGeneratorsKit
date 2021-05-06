namespace SourceGeneratorsKit
{
    using Microsoft.CodeAnalysis;

    /// <summary>
    /// Provides syntax context receivier which delegates work to multiple receivers.
    /// </summary>
    public class AggregateSyntaxContextReceiver: ISyntaxContextReceiver
    {
        public AggregateSyntaxContextReceiver(params ISyntaxContextReceiver[] receivers) => this.Receivers = receivers;

        public ISyntaxContextReceiver[] Receivers { get; }

        /// <inheritdoc/>
        public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
        {
            foreach (var receiver in this.Receivers)
            {
                receiver.OnVisitSyntaxNode(context);
            }
        }
    }
}

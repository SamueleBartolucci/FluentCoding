using System.Diagnostics.CodeAnalysis;

namespace FluentCoding.Test
{
    [ExcludeFromCodeCoverage]
    internal class TType
    {
        public TType() { }

        public string TDesc { get; set; } = nameof(TType);
    }
}
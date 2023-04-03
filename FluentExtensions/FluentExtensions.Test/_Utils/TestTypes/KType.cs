using System.Diagnostics.CodeAnalysis;

namespace FluentCoding.Test
{
    [ExcludeFromCodeCoverage]
    internal class KType
    {
        public KType() { }

        public string KDesc { get; set; } = nameof(KType);
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCodingTest
{
    [ExcludeFromCodeCoverage]
    internal class KType
    {
        public KType() { }

        public string KDesc { get; set; } = nameof(KType);
    }
}

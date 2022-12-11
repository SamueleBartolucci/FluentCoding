using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCodingTest
{
    [ExcludeFromCodeCoverage]
    internal class TypeK
    {
        public TypeK() { }

        public object K = new object();
        public string DescType { get; set; } = nameof(TypeK);
    }
}

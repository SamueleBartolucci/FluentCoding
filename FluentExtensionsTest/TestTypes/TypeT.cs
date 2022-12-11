using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCodingTest
{
    [ExcludeFromCodeCoverage]
    internal class TypeT
    {
        public TypeT() { }
        public string DescType { get; set; } = nameof(TypeT);
    }
}
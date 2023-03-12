using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding.Test
{
    [ExcludeFromCodeCoverage]
    internal class TType
    {
        public TType() { }
            
        public string TDesc { get; set; } = nameof(TType);
    }
}
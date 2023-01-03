using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding.String
{
    internal static class AllowStringExtensions
    {

        internal static IsNullOptions ToNullOptions(this IsNullWhen? allow)
            => allow.When(allow.HasValue).ThenMap(_ => _.Value.ToNullOptions(), _ => new IsNullOptions());

        internal static IsNullOptions ToNullOptions(this IsNullWhen allow)
            => new IsNullOptions() { EmptyStringIsNull = false }
                .When(allow.EqualsToAny(IsNullWhen.NullOrEmptyOrWhiteSpaces, IsNullWhen.NullOrEmpty))
                .Then(_ => _.EmptyStringIsNull = true)
                .When(allow.EqualsToAny(IsNullWhen.NullOrEmptyOrWhiteSpaces))
                .Then(_ => _.EmptyOrWhiteSpacesIsNull = true);
    }
}

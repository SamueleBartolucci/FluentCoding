using FluentCoding.When;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentCoding.String
{
    public static class Prepend
    {
        public static IEnumerable<string> PrependWhen(this IEnumerable<string> _, string stringToPrepend, bool doPrepend)
          => _.When(doPrepend).Then(sbj => sbj.Prepend(stringToPrepend));

        public static IEnumerable<string> PrependWhen(this IEnumerable<string> _, string stringToPrepend, Func<bool> doPrependWhen)
          => _.PrependWhen(stringToPrepend, doPrependWhen());
    }
}
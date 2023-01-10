using System;
using System.Runtime.CompilerServices;

namespace FluentCoding
{
    public static class IsExtensions
    {
        public static (bool IsSatisfied, T Subject) Is<T>(this T _, bool satisfyCondition)
            => (satisfyCondition, _);

        public static (bool IsSatisfied, T Subject) Is<T>(this T _, Func<bool> satisfyCondition)
            => _.Is(satisfyCondition());

        public static (bool IsSatisfied, T Subject) Is<T>(this T _, Func<T, bool> satisfyCondition)
            => _.Is(satisfyCondition(_));
    }
}
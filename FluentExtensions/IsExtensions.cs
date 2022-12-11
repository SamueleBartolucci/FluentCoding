using System;

namespace FluentExtensions
{
    public static class IsExtensions
    {
        public static (bool IsSatisfied, T Subject) Is<T>(this T _, Func<bool> satisfyCondition)
            => (satisfyCondition(), _);

        public static (bool IsSatisfied, T Subject) Is<T>(this T _, Func<T, bool> satisfyCondition)
            => (satisfyCondition(_), _);
    }
}
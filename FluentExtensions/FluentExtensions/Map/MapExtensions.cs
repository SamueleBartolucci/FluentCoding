using System;

namespace FluentCoding
{
    public static class MapExtensions
    {
        public static K Map<T, K>(this T _, Func<T, K> map) => _.IsNullOrEquivalent() ? default(K) : map(_);

        public static K Map<T, K>(this T _, Func<K> map) => map();
    }
}
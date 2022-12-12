using System;

namespace FluentExtensions
{
    public static class MapExtensions
    {
        public static K Map<T, K>(this T _, Func<T, K> map) => _.IsNullOrDefault()? default(K) : map(_);
    }
}
using System;

namespace FluentCoding
{
    public static class Map_T
    {
        public static K Map<T, K>(this T _, Func<T, K> map) => _.IsNullOrDefault() ? default(K) : map(_);
    }
}
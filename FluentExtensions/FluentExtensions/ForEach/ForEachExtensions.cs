using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding
{
    public static class ForEachExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
                action(item);
        }

        public static IEnumerable<K> ForEach<T, K>(this IEnumerable<T> items, Func<T, K> function)
        {
            var results = new List<K>();
            foreach (var item in items)
                results.Add(function(item));

            return results;
        }
    }
}

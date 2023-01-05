using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding
{
    public static class ForEachExtensions
    {
        /// <summary>
        /// Apply the action to each item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="action"></param>
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
                action(item);
        }


        /// <summary>
        /// Apply the map function to each item and collect the outputs as result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="items"></param>
        /// <param name="function"></param>
        /// <returns></returns>
        public static IEnumerable<K> ForEachMap<T, K>(this IEnumerable<T> items, Func<T, K> function)
        {
            var results = new List<K>();
            foreach (var item in items)
                results.Add(function(item));

            return results;
        }
    }
}

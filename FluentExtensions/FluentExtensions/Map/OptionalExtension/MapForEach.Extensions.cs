using System;
using System.Collections.Generic;

namespace FluentCoding
{
    public static partial class MapForEachExtensions
    {
        /// <summary>
        /// Apply a map function on each item from the subject  (when this is not null)
        /// Then return an enumerable with the result of each item function call
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="subject"></param>
        /// <param name="doOnSubject"></param>
        /// <returns></returns>
        public static IEnumerable<Optional<K>> MapForEach<T, K>(this IEnumerable<Optional<T>> subject, Func<T, K> doOnSubject)
        {
            List<Optional<K>> result = null;
            if (subject != null)
            {
                result = new List<Optional<K>>();
                foreach (var item in subject)
                    result.Add(item.Map(doOnSubject));
            }

            return result;
        }

    }
}
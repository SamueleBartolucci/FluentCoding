using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public static async Task<IEnumerable<K>> MapForEachAsync<T, K>(this Task<IEnumerable<T>> subject, Func<T, K> doOnSubject)
        {
            List<K> result = null;
            if (subject != null)
            {
                var sbjResult = await subject;
                if (sbjResult != null)
                {
                    result = new List<K>();
                    foreach (var item in sbjResult ?? new List<T>())
                        result.Add(doOnSubject(item));
                }
            }

            return result;
        }

    }
}
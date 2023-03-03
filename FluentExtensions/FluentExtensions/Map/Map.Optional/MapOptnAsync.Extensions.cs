using System;
using System.Threading.Tasks;

namespace FluentCoding
{
    public static partial class MapExtensions
    {
        /// <summary>
        /// Apply the mapping function on the subject and return the result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="subject"></param>
        /// <param name="mapSubject"></param>
        /// <returns></returns>
        public static async Task<Optional<K>> MapOptnAsync<T, K>(this Task<Optional<T>> subject, Func<T, K> mapSubject) 
            => (await subject).MapOptn(mapSubject);
    }
}
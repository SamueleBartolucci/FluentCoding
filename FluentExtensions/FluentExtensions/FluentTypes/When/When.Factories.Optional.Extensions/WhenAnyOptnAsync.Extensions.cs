using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentCoding
{
    public static partial class WhenAnyExtensions
    {
        /// <summary>
        /// Create a When contest and se IsSuccessful status if at leas one whenContition(item) from the subject Items is true
        /// Then set IsSuccessful accordingly
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whenSubject"></param>
        /// <param name="whenCondition"></param>
        /// <returns></returns>
        public static async Task<WhenOr<IEnumerable<Optional<T>>>> WhenAnyOptnAsync<T>(this Task<IEnumerable<Optional<T>>> whenSubject, Func<T, bool> whenCondition)
            => (await whenSubject).WhenAnyOpt(whenCondition);
    }
}

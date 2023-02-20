using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentCoding;

namespace FluentCoding
{
    public static partial class WhenAnyExtensions
    {
        /// <summary>
        /// Create a When contest and se IsSuccessfull status if at leas one whenContition(item) from the subject Items is true
        /// Then set IsSuccessfull accordingly
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whenSubject"></param>
        /// <param name="whenCondition"></param>
        /// <returns></returns>
        public static async Task<WhenOr<IEnumerable<T>>> WhenAnyAsync<T>(this Task<IEnumerable<T>> whenSubject, Func<T, bool> whenCondition)
            => (await whenSubject).WhenAny(whenCondition);
    }
}

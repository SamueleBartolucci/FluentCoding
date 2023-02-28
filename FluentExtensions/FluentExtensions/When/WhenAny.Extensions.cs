using System;
using System.Collections.Generic;
using System.Linq;
using FluentCoding;

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
        public static WhenOr<IEnumerable<T>> WhenAny<T>(this IEnumerable<T> whenSubject, Func<T, bool> whenCondition) =>
            new WhenOr<IEnumerable<T>>(whenSubject) { IsSuccessful = whenSubject.Any(i => whenCondition(i)) };
    }
}

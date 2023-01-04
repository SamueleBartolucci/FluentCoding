using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentCoding
{ 
    public static class WhenAny_T
    {
        /// <summary>
        /// Create a When contest and se IsSuccesfull status if at leas one whenContition(item) from the subject Items is true
        /// Then set IsSuccesfull accordingly
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whenSubject"></param>
        /// <param name="whenCondition"></param>
        /// <returns></returns>
        public static WhenOr<IEnumerable<T>> WhenAny<T>(this IEnumerable<T> whenSubject, Func<T, bool> whenCondition) =>
            new WhenOr<IEnumerable<T>>() { Subject = whenSubject, IsSuccesful = whenSubject.Any(i => whenCondition(i)) };
    }
}

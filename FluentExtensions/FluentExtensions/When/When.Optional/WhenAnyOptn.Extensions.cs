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
        public static WhenOr<IEnumerable<Optional<T>>> WhenAnyOpt<T>(this IEnumerable<Optional<T>> whenSubject, Func<T, bool> whenCondition) 
            =>  
            new WhenOr<IEnumerable<Optional<T>>>(whenSubject)
            {
                IsSuccessful = whenSubject != null &&                               
                               whenSubject.Any(i => i.IsSome() && whenCondition(i.Subject))
            };
    }
}

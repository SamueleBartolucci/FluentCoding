using System;
using System.Collections.Generic;
using System.Linq;
using FluentCoding;

namespace FluentCoding
{
    public static partial class WhenAnyExtensions
    {
        /// <summary>
        /// Create a When contest and set IsSuccessful status true if at least one whenContition(item) from the subject Items is true        
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whenSubject"></param>
        /// <param name="whenCondition"></param>
        /// <returns></returns>
        public static WhenOr<IEnumerable<T>> WhenAny<T>(this IEnumerable<T> whenSubject, Func<T, bool> whenCondition) =>
            new WhenOr<IEnumerable<T>>(whenSubject) { IsSuccessful = whenSubject != null && whenSubject.Any(i => whenCondition(i)) };

        /// <summary>
        /// Create a When contest and set IsSuccessful status true if exists at least one element        
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whenSubject"></param>        
        /// <returns></returns>
        public static WhenOr<IEnumerable<T>> WhenAny<T>(this IEnumerable<T> whenSubject) =>
            new WhenOr<IEnumerable<T>>(whenSubject) { IsSuccessful = whenSubject != null && whenSubject.Any() };

        /// <summary>
        /// Create a When contest and set IsSuccessful status true if empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whenSubject"></param>        
        /// <returns></returns>
        public static WhenOr<IEnumerable<T>> WhenEmptyOrNull<T>(this IEnumerable<T> whenSubject) =>
            new WhenOr<IEnumerable<T>>(whenSubject) { IsSuccessful = whenSubject == null || !whenSubject.Any() };
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace FluentCoding
{
    public static partial class DoForEachExtensions
    {
        /// <summary>
        /// Apply a set of actions to the subject when this is not null then return the subject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumeratorSubject"></param>
        /// <param name="doOnItemActions"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<T> DoForEach<T>(this IEnumerable<T> enumeratorSubject, params Action<T>[] doOnItemActions)
        {
            if (enumeratorSubject != null && enumeratorSubject.Any())
            {
                foreach (var currentItem in enumeratorSubject)
                    foreach (var actionToApply in doOnItemActions)
                        actionToApply(currentItem);
            }

            return enumeratorSubject;
        }

        /// <summary>
        /// Apply a set of functions on each item from the subject (when this is not null)
        /// Then return the subject Enumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="enumeratorSubject"></param>
        /// <param name="doOnItemActions"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<T> DoForEach<T>(this IEnumerable<T> enumeratorSubject, params Func<T, T>[] doOnItemActions)
        {            
            if (enumeratorSubject != null)
            {         
                foreach (var currentItem in enumeratorSubject)
                    foreach (var actionToApply in doOnItemActions)
                        actionToApply(currentItem);
            }
            return enumeratorSubject;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace FluentCoding
{
    public static partial class DoForEachExtensions
    {
        /// <summary>
        /// Apply a set of actions to the subject when this is not null then return the subject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject"></param>
        /// <param name="doOnItem"></param>
        /// <returns></returns>
        public static IEnumerable<T> DoForEach<T>(this IEnumerable<T> subject, params Action<T>[] doOnItem)
        {
            if (subject != null)
            {
                foreach (var item in subject)
                    foreach (var doOnSbj in doOnItem)
                        doOnSbj(item);
            }

            return subject;
        }

        /// <summary>
        /// Apply a set of functions on each item from the subject (when this is not null)
        /// Then return the subject Enumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="subject"></param>
        /// <param name="doOnItem"></param>
        /// <returns></returns>
        public static IEnumerable<T> DoForEach<T>(this IEnumerable<T> subject, params Func<T, T>[] doOnItem)
        {            
            if (subject != null)
            {         
                foreach (var item in subject)
                    foreach (var doOnSbj in doOnItem)
                        doOnSbj(item);
            }
            return subject;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace FluentCoding
{
    public static class DoForAllExtensions
    {
        /// <summary>
        /// Apply a function on each item from the subject when this is not null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject"></param>
        /// <param name="doOnItem"></param>
        /// <returns></returns>
        public static IEnumerable<T> DoForAll<T>(this IEnumerable<T> subject, Func<T, T> doOnItem)
        {
            foreach (var item in subject ?? new List<T>())
                doOnItem(item);

            return subject;
        }


        /// <summary>
        /// Apply an action on the subject when this is not null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject"></param>
        /// <param name="doOnItem"></param>
        /// <returns></returns>
        public static IEnumerable<T> DoForAll<T>(this IEnumerable<T> subject, Action<T> doOnItem)
        {
            foreach (var item in subject ?? new List<T>())
                doOnItem(item);

            return subject;
        }

        /// <summary>
        /// Apply an set of actions on the subject when this is not null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject"></param>
        /// <param name="doOnItem"></param>
        /// <returns></returns>
        public static IEnumerable<T> DoForAll<T>(this IEnumerable<T> subject, params Action<T>[] doOnItem)
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
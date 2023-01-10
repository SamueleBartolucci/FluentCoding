using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace FluentCoding
{
    public static partial class DoForAllExtensions
    {
        /// <summary>
        /// Apply an action on the subject when this is not null then return the subject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject"></param>
        /// <param name="doOnItem"></param>
        /// <returns></returns>
        public static IEnumerable<T> DoForAll<T>(this IEnumerable<T> subject, Action<T> doOnItem)
        {
            if(subject != null)
                foreach (var item in subject ?? new List<T>())
                    doOnItem(item);

            return subject;
        }

        /// <summary>
        /// Apply a set of actions to the subject when this is not null then return the subject
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


        /// <summary>
        /// Apply a function on each item from the subject when this is not null then return the subject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject"></param>
        /// <param name="doOnItem"></param>
        /// <returns></returns>
        public static IEnumerable<T> DoForAll<T>(this IEnumerable<T> subject, Func<T, T> doOnItem)
        {
            if (subject != null)
                foreach (var item in subject ?? new List<T>())
                    doOnItem(item);

            return subject;
        }



        /// <summary>
        /// Apply a set of functions on each item from the subject when this is not null then return the subject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject"></param>
        /// <param name="doOnItem"></param>
        /// <returns></returns>
        public static IEnumerable<T> DoForAll<T>(this IEnumerable<T> subject, params Func<T, T>[] doOnItem)
        {
            if (subject != null)
                foreach (var item in subject ?? new List<T>())
                    foreach (var doOnSbj in doOnItem)
                        doOnSbj(item);

            return subject;
        }



        /// <summary>
        /// Apply the map function to each item and collect the outputs as result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="items"></param>
        /// <param name="mapOnItem"></param>
        /// <returns></returns>
        public static IEnumerable<K> DoForAllMap<T, K>(this IEnumerable<T> items, Func<T, K> mapOnItem)
        {
            var results = new List<K>();
            foreach (var item in items)
                results.Add(mapOnItem(item));

            return results;
        }
    }
}
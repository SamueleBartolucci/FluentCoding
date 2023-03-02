using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace FluentCoding
{
    public static partial class DoOptionalExtensions
    {
        /// <summary>
        /// Apply a set of actions to the Optional subject when IsSome then return the subject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject"></param>
        /// <param name="doOnItem"></param>
        /// <returns></returns>
        public static IEnumerable<Optional<T>> DoOptnForEach<T>(this IEnumerable<Optional<T>> subject, params Action<T>[] doOnItem)
        {
            foreach (var item in subject ?? new List<Optional<T>>())
                item.DoOptn(doOnItem);

            return subject;
        }

        /// <summary>
        /// Apply a set of functions on each Optional item when IsSome
        /// Then return the subject Enumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="subject"></param>
        /// <param name="doOnItem"></param>
        /// <returns></returns>
        public static IEnumerable<Optional<T>> DoOptnForEach<T>(this IEnumerable<Optional<T>> subject, params Func<T, T>[] doOnItem)
        {
            foreach (var item in subject ?? new List<Optional<T>>())
                item.DoOptn(doOnItem);

            return subject;
        }
    }
}
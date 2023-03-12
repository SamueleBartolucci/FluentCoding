using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FluentCoding
{
    public static partial class DoOptionalExtensions
    {
        /// <summary>
        /// Apply a set of actions on each Optional item when IsSome from the subject Task enumerable
        /// Then return the subject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject"></param>
        /// <param name="doOnItem"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<Optional<T>>> DoOptnForEachAsync<T>(this Task<IEnumerable<Optional<T>>> subject, params Action<T>[] doOnItem)
            => (await subject).DoOptnForEach(doOnItem);


        /// <summary>
        /// Apply a set of functions on each Optional item when IsSome from the subject Task enumerable
        /// Then return the subject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject"></param>
        /// <param name="doOnItem"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<Optional<T>>> DoOptnForEachAsync<T>(this Task<IEnumerable<Optional<T>>> subject, params Func<T, T>[] doOnItem)
            => (await subject).DoOptnForEach(doOnItem);       
    }
}
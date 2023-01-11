using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FluentCoding
{
    public static partial class DoForEachExtensions
    {
        /// <summary>
        /// Apply a set of actions to the subject (when not null)
        /// Then return the subject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject"></param>
        /// <param name="doOnItem"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> DoForEachAsync<T>(this Task<IEnumerable<T>> subject, params Action<T>[] doOnItem)
            => (await subject).DoForEach(doOnItem);

       
        /// <summary>
        /// Apply a set of functions on each item from the subject (when not null)
        /// Then return the subject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject"></param>
        /// <param name="doOnItem"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> DoForEachAsync<T>(this Task<IEnumerable<T>> subject, params Func<T, T>[] doOnItem)
            => (await subject).DoForEach(doOnItem);       
    }
}
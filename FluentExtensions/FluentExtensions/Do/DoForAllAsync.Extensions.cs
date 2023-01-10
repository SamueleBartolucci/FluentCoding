using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public static async Task<IEnumerable<T>> DoForAllAsync<T>(this Task<IEnumerable<T>> subject, Action<T> doOnItem)
            => (await subject).DoForAll(doOnItem);
        //{
        //    var sbj = default(IEnumerable<T>);

        //    if (subject != null)
        //    {
        //        sbj = await subject;
        //        foreach (var item in sbj ?? new List<T>())
        //            doOnItem(item);
        //    }

        //    return sbj;
        //}

        /// <summary>
        /// Apply a set of actions to the subject when this is not null then return the subject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject"></param>
        /// <param name="doOnItem"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> DoForAllAsync<T>(this Task<IEnumerable<T>> subject, params Action<T>[] doOnItem)
            => (await subject).DoForAll(doOnItem);
        //{
        //    var sbj = default(IEnumerable<T>);

        //    if (subject != null)
        //    {
        //        sbj = await subject;
        //        foreach (var item in sbj ?? new List<T>())
        //            foreach (var doOnSbj in doOnItem)
        //                doOnSbj(item);
        //    }

        //    return sbj;            
        //}


        /// <summary>
        /// Apply a function on each item from the subject when this is not null then return the subject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject"></param>
        /// <param name="doOnItem"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> DoForAllAsync<T>(this Task<IEnumerable<T>> subject, Func<T, T> doOnItem)
            => (await subject).DoForAll(doOnItem);
        //{
        //    var sbj = default(IEnumerable<T>);

        //    if (subject != null)
        //    {
        //        sbj = await subject;
        //        foreach (var item in sbj ?? new List<T>())
        //            doOnItem(item);
        //    }

        //    return sbj;
        //}



        /// <summary>
        /// Apply a set of functions on each item from the subject when this is not null then return the subject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject"></param>
        /// <param name="doOnItem"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> DoForAllAsync<T>(this Task<IEnumerable<T>> subject, params Func<T, T>[] doOnItem)
            => (await subject).DoForAll(doOnItem);
        //{
        //    var sbj = default(IEnumerable<T>);

        //    if (subject != null)
        //    {
        //        sbj = await subject;
        //        foreach (var item in sbj ?? new List<T>())
        //            foreach (var doOnSbj in doOnItem)
        //                doOnSbj(item);
        //    }

        //    return sbj;
        //}


        /// <summary>
        /// Apply the map function to each item and collect the outputs as result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="items"></param>
        /// <param name="mapOnItem"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<K>> DoForAllMapAsync<T, K>(this Task<IEnumerable<T>> items, Func<T, K> mapOnItem)
        => (await items).DoForAllMap(mapOnItem);
    }
}
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FluentCoding
{
    public static partial class SwitchMapExtensions
    {
        /// <summary>
        /// Search the first whenPredicate(subject) == true and apply its  mapActionWhenTrue(subject)
        /// If Option T IsNone returns None of K
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="subject"></param>
        /// <param name="defaultAction"></param>
        /// <param name="cases"></param>
        /// <returns></returns>
        public static async Task<Optional<K>> SwitchOptnAsync<T, K>(this Task<Optional<T>> subject, Func<T, K> defaultAction, params (Func<T, bool> whenPredicate, Func<T, K> mapActionWhenTrue)[] cases)
             => (await subject).SwitchOptn(defaultAction, cases);

        /// <summary>
        /// Search the first whenPredicate() == true and apply its mapActionWhenTrue(subject)
        /// If Option T IsNone returns None of K
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="subject"></param>
        /// <param name="defaultAction"></param>
        /// <param name="cases"></param>
        /// <returns></returns>
        public static async Task<Optional<K>> SwitchOptnAsync<T, K>(this Task<Optional<T>> subject, Func<T, K> defaultAction, params (Func<bool> whenPredicate, Func<T, K> mapActionWhenTrue)[] cases)
            => (await subject).SwitchOptn(defaultAction, cases);

        /// <summary>
        /// Search the first whenPredicate == true and apply its mapActionWhenTrue(subject)
        /// If Option T IsNone returns None of K
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="subject"></param>
        /// <param name="defaultAction"></param>
        /// <param name="cases"></param>
        /// <returns></returns>
        public static async Task<Optional<K>> SwitchOptnAsync<T, K>(this Task<Optional<T>> subject, Func<T, K> defaultAction, params (bool whenPredicate, Func<T, K> mapActionWhenTrue)[] cases)
            => (await subject).SwitchOptn(defaultAction, cases);
    }
}
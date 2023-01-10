using System;
using System.Linq;
using System.Threading.Tasks;

namespace FluentCoding
{
    public static partial class SwitchExtensions
    {
        /// <summary>
        /// Search the first whenPredicate(subject) == true and apply its  actionWhenTrue(subject)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject"></param>
        /// <param name="defaultAction"></param>
        /// <param name="cases"></param>
        /// <returns></returns>
        public static async Task<T> SwitchAsync<T>(this Task<T> subject, Func<T, T> defaultAction, params (Func<T, bool> whenPredicate, Func<T, T> actionWhenTrue)[] cases)
            => (await subject).Switch(defaultAction, cases);

        /// <summary>
        /// Search the first whenPredicate() == true and apply its actionWhenTrue(subject)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject"></param>
        /// <param name="defaultAction"></param>
        /// <param name="cases"></param>
        /// <returns></returns>
        public static async Task<T> SwitchAsync<T>(this Task<T> subject, Func<T, T> defaultAction, params (Func<bool> whenPredicate, Func<T, T> actionWhenTrue)[] cases)
             => (await subject).Switch(defaultAction, cases);


        /// <summary>
        /// Search the first whenPredicate == true and apply its actionWhenTrue(subject)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject"></param>
        /// <param name="defaultAction"></param>
        /// <param name="cases"></param>
        /// <returns></returns>
        public static async Task<T> SwitchAsync<T>(this Task<T> subject, Func<T, T> defaultAction, params (bool whenPredicate, Func<T, T> actionWhenTrue)[] cases)
          => (await subject).Switch(defaultAction, cases);


    }
}
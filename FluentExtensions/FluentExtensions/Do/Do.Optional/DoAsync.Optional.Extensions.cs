using System;
using System.Threading.Tasks;

namespace FluentCoding
{
    public static partial class DoOptionalExtensions
    {

        /// <summary>
        /// Apply an set of actions to the subject when this is not null then return the subject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_"></param>
        /// <param name="doOnSubject"></param>
        /// <returns></returns>
        public static async Task<Optional<T>> DoOptionalAsync<T>(this Task<Optional<T>> _, params Action<T>[] doOnSubject)
            => (await _).DoOptional(doOnSubject);

        /// <summary>
        /// Apply a set of function on the subject when this is not null then return the Func result or the subject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_"></param>
        /// <param name="doOnSubject"></param>
        /// <returns></returns>
        public static async Task<Optional<T>> DoOptionalAsync<T>(this Task<Optional<T>> _, params Func<T, T>[] doOnSubject)
            => (await _).DoOptional(doOnSubject);
    }
}
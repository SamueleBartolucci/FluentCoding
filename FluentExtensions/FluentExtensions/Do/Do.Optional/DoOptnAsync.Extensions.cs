using System;
using System.Threading.Tasks;

namespace FluentCoding
{
    public static partial class DoOptionalExtensions
    {

        /// <summary>
        /// Apply an set of actions to the Optional subject when IsSome then return the subject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_"></param>
        /// <param name="doOnSubject"></param>
        /// <returns></returns>
        public static async Task<Optional<T>> DoOptnAsync<T>(this Task<Optional<T>> _, params Action<T>[] doOnSubject)
            => (await _).DoOptn(doOnSubject);

        /// <summary>
        /// Apply a set of function to the Optional subject when IsSome then return the Func result or the subject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_"></param>
        /// <param name="doOnSubject"></param>
        /// <returns></returns>
        public static async Task<Optional<T>> DoOptnAsync<T>(this Task<Optional<T>> _, params Func<T, T>[] doOnSubject)
            => (await _).DoOptn(doOnSubject);
    }
}
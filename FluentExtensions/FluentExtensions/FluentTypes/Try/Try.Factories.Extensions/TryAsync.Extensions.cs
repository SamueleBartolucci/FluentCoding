using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;


namespace FluentCoding
{
    public static partial class TryExtensions
    {
        /// <summary>
        /// Execute a Function and then return the TryCatch context
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="R"></typeparam>
        /// <param name="_"></param>
        /// <param name="tryTo"></param>
        /// <returns></returns>
        public static async Task<TryCatch<S, R, Exception>> TryAsync<S, R>(this Task<S> _, Func<S, R> tryTo)
            => (await _).Try(tryTo);

        /// <summary>
        /// Execute a Function and (when raised) manage the exception, Then return the TryCatch context
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="R"></typeparam>
        /// <typeparam name="E"></typeparam>
        /// <param name="_"></param>
        /// <param name="tryTo"></param>
        /// <param name="onError"></param>
        /// <returns></returns>
        public static async Task<TryCatch<S, R, E>> TryAsync<S, R, E>(this Task<S> _, Func<S, R> tryTo, Func<S, Exception, E> onError)
            => (await _).Try(tryTo, onError);

        /// <summary>
        /// Execute aa Action and (when raised) manage the exception, Then return the TryCatch context
        /// The result is the same as the subject
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="E"></typeparam>
        /// <param name="_"></param>
        /// <param name="tryTo"></param>
        /// <param name="onError"></param>
        /// <returns></returns>
        public static async Task<TryCatch<S, S, E>> TryAsync<S, E>(this Task<S> _, Action<S> tryTo, Func<S, Exception, E> onError)
            => (await _).Try(tryTo, onError);


        /// <summary>
        /// Execute a Function and return its output
        /// When an exception is raised, apply the map function and then return its result
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="R"></typeparam>
        /// <param name="_"></param>
        /// <param name="tryTo"></param>
        /// <param name="onError"></param>
        /// <returns></returns>
        public static async Task<R> TryToAsync<S, R>(this Task<S> _, Func<S, R> tryTo, Func<S, Exception, R> onError)
            => (await _).TryTo(tryTo, onError);

    }

}
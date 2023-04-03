using System;

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
        public static TryCatch<S, R, Exception> Try<S, R>(this S _, Func<S, R> tryTo) =>
            new TryCatch<S, R, Exception>(_) { }
            .Try(tryTo, (s, e) => e);

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
        public static TryCatch<S, R, E> Try<S, R, E>(this S _, Func<S, R> tryTo, Func<S, Exception, E> onError) =>
            new TryCatch<S, R, E>(_) { }
            .Try(tryTo, onError);


        /// <summary>
        /// Execute an Action and (when raised) manage the exception, Then return the TryCatch context
        /// The result is the same as the subject
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="E"></typeparam>
        /// <param name="_"></param>
        /// <param name="tryTo"></param>
        /// <param name="onError"></param>
        /// <returns></returns>
        public static TryCatch<S, S, E> Try<S, E>(this S _, Action<S> tryTo, Func<S, Exception, E> onError) =>
            new TryCatch<S, S, E>(_) { Result = _ }
            .Try(tryTo, onError);


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
        public static R TryTo<S, R>(this S _, Func<S, R> tryTo, Func<S, Exception, R> onError) =>
           _.Try(tryTo, onError)
            .Map(tryCatch => tryCatch.IsSuccessful ? tryCatch.Result : tryCatch.Error);
    }

}
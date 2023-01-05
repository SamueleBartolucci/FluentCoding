using System;

namespace FluentCoding
{
    public static class DoExtensions
    {
        /// <summary>
        /// Apply a function on the subject when this is not null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_"></param>
        /// <param name="doOnSubject"></param>
        /// <returns></returns>
        public static T Do<T>(this T _, Func<T, T> doOnSubject)
            => _ != null ? doOnSubject(_) : _;


        /// <summary>
        /// Apply an action on the subject when this is not null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_"></param>
        /// <param name="doOnSubject"></param>
        /// <returns></returns>
        public static T Do<T>(this T _, Action<T> doOnSubject)
        {
            if (_ != null) doOnSubject(_);

            return _;
        }

        /// <summary>
        /// Apply an set of actions on the subject when this is not null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_"></param>
        /// <param name="doOnSubject"></param>
        /// <returns></returns>
        public static T Do<T>(this T _, params Action<T>[] doOnSubject)
        {
            if (_ != null)
            {
                foreach (var doOnSbj in doOnSubject)
                    doOnSbj(_);
            }

            return _;
        }
    }
}
using System;

namespace FluentCoding
{
    public static partial class DoExtensions
    {
        /// <summary>
        /// Apply an action on the subject when this is not null then return the subject
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
        /// Apply an set of actions to the subject when this is not null then return the subject
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


        /// <summary>
        /// Apply a function on the subject when this is not null then return the Func result or the subject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_"></param>
        /// <param name="doOnSubject"></param>
        /// <returns></returns>
        public static T Do<T>(this T _, Func<T, T> doOnSubject)
            => _ != null ? doOnSubject(_) : _;



        /// <summary>
        /// Apply an set of function to the subject when this is not null then return the subject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_"></param>
        /// <param name="doOnSubject"></param>
        /// <returns></returns>
        public static T Do<T>(this T _, params Func<T, T>[] doOnSubject)
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
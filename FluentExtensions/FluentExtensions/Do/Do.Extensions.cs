using System;

namespace FluentCoding
{
    public static partial class DoExtensions
    {
        /// <summary>
        /// Apply an set of actions to the subject (when this is not null)
        /// Then return the subject
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
        /// Apply an set of function to the subject  (when this is not null)
        /// Then return the subject
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
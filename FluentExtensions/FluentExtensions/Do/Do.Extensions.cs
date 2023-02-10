using System;
using System.Diagnostics.CodeAnalysis;

namespace FluentCoding
{
    public static partial class DoExtensions
    {
        /// <summary>
        /// Apply a set of actions to the Subject (when this is not null) wrapped inside and Context&lt;T&gt;.Subject field.
        /// Allows to quickly manipulate values type as references types
        /// Then return the subject unwrapped, only the return value is changed not the original value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_"></param>
        /// <param name="doOnSubject"></param>
        /// <returns></returns>
        public static T DoWrap<T>(this T _, params Action<Context<T>>[] doOnSubject)
        {
            var tmp = new Context<T>() { Subject = _ };

            if (_ != null)
            {
                tmp.Do(doOnSubject);
                //foreach (var doOnSbj in doOnSubject)
                //    doOnSbj(tmp);
            }

            return tmp.Subject;
        }

        /// <summary>
        /// Apply a set of actions to the subject (when this is not null)
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
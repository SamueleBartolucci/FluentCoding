using System;
using System.Xml.Linq;


namespace FluentCoding
{
    public static partial class WhenExtensions
    {
        /// <summary>
        /// Create a When context and set IsSuccessful status with the result of whenCondition(subject)
        /// Then set IsSuccessful accordingly
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whenSubject"></param>
        /// <param name="whenCondition"></param>
        /// <returns></returns>
        public static WhenOr<T> When<T>(this T whenSubject, Func<T, bool> whenCondition) 
            => new WhenOr<T>(whenSubject) { IsSuccessful = whenCondition(whenSubject) };

        /// <summary>
        /// Create a When context and set IsSuccessful status with the result of whenCondition()
        /// Then set IsSuccessful accordingly
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whenSubject"></param>
        /// <param name="whenCondition"></param>
        /// <returns></returns>
        public static WhenOr<T> When<T>(this T whenSubject, Func<bool> whenCondition)
            => new WhenOr<T>(whenSubject) { IsSuccessful = whenCondition() };

        /// <summary>
        /// Create a When context and set IsSuccessful status with the value of whenCondition
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whenSubject"></param>
        /// <param name="whenCondition"></param>
        /// <returns></returns>
        public static WhenOr<T> When<T>(this T whenSubject, bool whenCondition)
            => new WhenOr<T>(whenSubject) { IsSuccessful = whenCondition };
    }
}

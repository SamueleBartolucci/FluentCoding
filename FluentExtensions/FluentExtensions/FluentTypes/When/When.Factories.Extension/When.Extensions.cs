using System;
using System.Collections.Generic;


namespace FluentCoding
{
    public static partial class WhenExtensions
    {
        /// <summary>
        /// Create a When context and set IsSuccessful status with the result of whenCondition(subject)        
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whenSubject"></param>
        /// <param name="whenCondition"></param>
        /// <returns></returns>
        public static WhenOr<T> When<T>(this T whenSubject, Func<T, bool> whenCondition)
            => new WhenOr<T>(whenSubject) { IsSuccessful = whenCondition(whenSubject) };

        /// <summary>
        /// Create a When context and set IsSuccessful status with the result of whenCondition()        
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


        /// <summary>
        /// Create a When context and set IsSuccessful status true if IsNullOrEquivalent
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whenSubject"></param>
        /// <returns></returns>
        public static WhenOr<T> WhenIsNullOrEquivalent<T>(this T whenSubject)
            => new WhenOr<T>(whenSubject) { IsSuccessful = whenSubject.IsNullOrEquivalent() };

        /// <summary>
        /// Create a When context and set IsSuccessful status true if not IsNullOrEquivalent
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whenSubject"></param>
        /// <returns></returns>
        public static WhenOr<T> WhenIsNotNullOrEquivalent<T>(this T whenSubject)
            => new WhenOr<T>(whenSubject) { IsSuccessful = whenSubject.IsNotNullOrEquivalent() };


        /// <summary>
        /// Create a When context and set IsSuccessful to true if equals to comparable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whenSubject"></param>
        /// <param name="comparable"></param>
        /// <returns></returns>
        public static WhenOr<T> WhenEqualsTo<T>(this T whenSubject, T comparable) where T : IComparable
            => new WhenOr<T>(whenSubject) { IsSuccessful = whenSubject?.Equals(comparable) ?? false };


        /// <summary>
        /// Create a When context and set IsSuccessful to the value of the subject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whenSubject"></param>
        /// <returns></returns>
        public static WhenOr<bool> WhenIsTrue(this bool whenSubject)
            => new WhenOr<bool>(whenSubject) { IsSuccessful = whenSubject };

        /// <summary>
        /// Create a When context and set IsSuccessful = true when subject is false
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whenSubject"></param>
        /// <returns></returns>
        public static WhenOr<bool> WhenIsFalse(this bool whenSubject)
            => new WhenOr<bool>(whenSubject) { IsSuccessful = !whenSubject };



        /// <summary>
        /// Apply the Function mapWhenTrue or mapWhenFalse on each item from the subject
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <param name="when"></param>
        /// <param name="mapWhenTrue"></param>
        /// <param name="mapWhenFalse"></param>
        /// <returns></returns>
        public static IEnumerable<K> ThenForAll<T, K>(this When<IEnumerable<T>> when, Func<T, K> mapWhenTrue, Func<T, K> mapWhenFalse)
            => when.Subject.MapForEach(mapWhenTrue.Or(mapWhenFalse, !when.IsSuccessful));
    }
}

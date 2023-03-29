using System;
using System.Threading.Tasks;
using System.Xml.Linq;
using FluentCoding;

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
        public static async Task<WhenOr<T>> WhenAsync<T>(this Task<T> whenSubject, Func<T, bool> whenCondition)
            => (await whenSubject).When(whenCondition);

        /// <summary>
        /// Create a When context and set IsSuccessful status with the result of whenCondition()
        /// Then set IsSuccessful accordingly
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whenSubject"></param>
        /// <param name="whenCondition"></param>
        /// <returns></returns>
        public static async Task<WhenOr<T>> WhenAsync<T>(this Task<T> whenSubject, Func<bool> whenCondition)
            => (await whenSubject).When(whenCondition);

        /// <summary>
        /// Create a When context and set IsSuccessful status with the value of whenCondition
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whenSubject"></param>
        /// <param name="whenCondition"></param>
        /// <returns></returns>
        public static async Task<WhenOr<T>> WhenAsync<T>(this Task<T> whenSubject, bool whenCondition)
            => (await whenSubject).When(whenCondition);


        /// <summary>
        /// Create a When context and set IsSuccessful status true if IsNullOrEquivalent
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whenSubject"></param>
        /// <returns></returns>
        public static async Task<WhenOr<T>> WhenIsNullOrEquivalentAsync<T>(this Task<T> whenSubject)
            => (await whenSubject).WhenIsNullOrEquivalent();

        /// <summary>
        /// Create a When context and set IsSuccessful status true if not IsNullOrEquivalent
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whenSubject"></param>
        /// <returns></returns>
        public static async Task<WhenOr<T>> WhenIsNotNullOrEquivalentAsync<T>(this Task<T> whenSubject)
            => (await whenSubject).WhenIsNotNullOrEquivalent();


        /// <summary>
        /// Create a When context and set IsSuccessful to true if equals to comparable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whenSubject"></param>
        /// <param name="comparable"></param>
        /// <returns></returns>
        public static async Task<WhenOr<T>> WhenEqualsToAsync<T>(this Task<T> whenSubject, T comparable) where T : IComparable
             => (await whenSubject).WhenEqualsTo(comparable);
    }
}

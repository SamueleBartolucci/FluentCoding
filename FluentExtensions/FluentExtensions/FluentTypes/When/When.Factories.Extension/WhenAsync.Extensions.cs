using System;
using System.Threading.Tasks;
/* Unmerged change from project 'FluentCoding (netstandard2.1)'
Before:
using System.Xml.Linq;
using FluentCoding;
After:
using System.Xml.Linq;
*/

/* Unmerged change from project 'FluentCoding (net48)'
Before:
using System.Xml.Linq;
using FluentCoding;
After:
using System.Xml.Linq;
*/

/* Unmerged change from project 'FluentCoding (netstandard2.0)'
Before:
using System.Xml.Linq;
using FluentCoding;
After:
using System.Xml.Linq;
*/


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


        /// <summary>
        /// Create a When context and set IsSuccessful to the value of the subject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whenSubject"></param>
        /// <returns></returns>
        public static async Task<WhenOr<bool>> WhenIsTrueAsync(this Task<bool> whenSubject)
           => (await whenSubject).WhenIsTrue();


        /// <summary>
        /// Create a When context and set IsSuccessful = true when subject is false
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whenSubject"></param>
        /// <returns></returns>
        public static async Task<WhenOr<bool>> WhenIsFalseAsync(this Task<bool> whenSubject)
            => (await whenSubject).WhenIsFalse();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentCoding;

namespace FluentCoding
{
    public static partial class WhenAnyExtensions
    {
        /// <summary>
        /// Create a When contest and set IsSuccessful status true if at least one whenContition(item) from the subject Items is true
        /// Then set IsSuccessful accordingly
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whenSubject"></param>
        /// <param name="whenCondition"></param>
        /// <returns></returns>
        public static async Task<WhenOr<IEnumerable<T>>> WhenAnyAsync<T>(this Task<IEnumerable<T>> whenSubject, Func<T, bool> whenCondition)
            => (await whenSubject).WhenAny(whenCondition);


        /// <summary>
        /// Create a When contest and set IsSuccessful status true if exists at least one element        
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whenSubject"></param>        
        /// <returns></returns>
        public static async Task<WhenOr<IEnumerable<T>>> WhenAnyAsync<T>(this Task<IEnumerable<T>> whenSubject)
            => (await whenSubject).WhenAny();

        /// <summary>
        /// Create a When contest and set IsSuccessful status true if empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whenSubject"></param>        
        /// <returns></returns>
        public static async Task<WhenOr<IEnumerable<T>>> WhenEmptyOrNullAsync<T>(this Task<IEnumerable<T>> whenSubject)
           => (await whenSubject).WhenEmptyOrNull();
    }
}

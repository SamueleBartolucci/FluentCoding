using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding
{
    public static partial class EqualsExtensions
    {
        /// <summary>
        /// Search if at least one item from the domains match the input value
        /// Basic Equals from framework is used as comparison
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject"></param>
        /// <param name="valuesToCompareWith"></param>
        /// <returns></returns>
        public static async Task<bool> EqualsToAnyAsync<T>(Task<T> subject, params T[] valuesToCompareWith)
            => (await subject).EqualsToAny(valuesToCompareWith);

        /// <summary>
        /// Search if at least one item from the domains match the input value
        /// The provided equalityComparison function is used as comparison
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject"></param>
        /// <param name="equalityComparison"></param>
        /// <param name="valuesToCompareWith"></param>
        /// <returns></returns>
        public static async Task<bool> EqualsToAnyAsync<T>(Task<T> subject, Func<T, T, bool> equalityComparison, params T[] valuesToCompareWith)
            => (await subject).EqualsToAny(equalityComparison, valuesToCompareWith);

        /// <summary>
        /// Check if the two object are equals using the provided compare function
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject"></param>
        /// <param name="checkAgainst"></param>
        /// <param name="valuesToCompareWith"></param>
        /// <returns></returns>
        public static async Task<bool> EqualsToAsync<T>(Task<T> subject, T checkAgainst, Func<T, T, bool> valuesToCompareWith)
            => (await subject).EqualsTo(checkAgainst, valuesToCompareWith);

    }
}

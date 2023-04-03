using System;
using System.Threading.Tasks;

namespace FluentCoding
{
    public static partial class EquivalentExtensions
    {
        /// <summary>
        /// Search if at least one item from the domains match the input value
        /// The provided equalityComparison function is used as comparison
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="subject"></param>
        /// <param name="equivalentComparison"></param>
        /// <param name="valuesToCompareWith"></param>
        /// <returns></returns>
        public static async Task<bool> EquivalentToAnyAsync<T, K>(this Task<T> subject, Func<T, K, bool> equivalentComparison, params K[] valuesToCompareWith)
            => (await subject).EquivalentToAny(equivalentComparison, valuesToCompareWith);

        /// <summary>
        /// Check if the two object are 'equals' using the provided compare function
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="subject"></param>
        /// <param name="checkAgainst"></param>
        /// <param name="equalityComparison"></param>
        /// <returns></returns>
        public static async Task<bool> EquivalentToAsync<T, K>(this Task<T> subject, K checkAgainst, Func<T, K, bool> equalityComparison)
            => (await subject).EquivalentTo(checkAgainst, equalityComparison);
    }
}

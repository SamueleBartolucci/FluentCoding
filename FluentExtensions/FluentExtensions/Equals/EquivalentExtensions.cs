using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding
{
    public static class EquivalentExtensions
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
        public static bool EquivalentToAny<T, K>(this T subject, Func<T, K, bool> equivalentComparison, params K[] valuesToCompareWith)
            => subject != null && valuesToCompareWith.Any(domainValue => subject.EquivalentTo(domainValue, equivalentComparison));

        /// <summary>
        /// Check if the two object are 'equals' using the provided compare function
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="subject"></param>
        /// <param name="checkAgainst"></param>
        /// <param name="equalityComparison"></param>
        /// <returns></returns>
        public static bool EquivalentTo<T, K>(this T subject, K checkAgainst, Func<T, K, bool> equalityComparison)
            => subject != null && equalityComparison(subject, checkAgainst);
    }
}

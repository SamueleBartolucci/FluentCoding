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
        public static bool EqualsToAny<T>(this T subject, params T[] valuesToCompareWith)
            => subject != null && valuesToCompareWith.Any(domainValue => subject.Equals(domainValue));

        /// <summary>
        /// Search if at least one item from the domains match the input value
        /// The provided equalityComparison function is used as comparison
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject"></param>
        /// <param name="equalityComparison"></param>
        /// <param name="valuesToCompareWith"></param>
        /// <returns></returns>
        public static bool EqualsToAny<T>(this T subject, Func<T, T, bool> equalityComparison, params T[] valuesToCompareWith)
            => subject != null && valuesToCompareWith.Any(domainValue => subject.EqualsTo(domainValue, equalityComparison));


        /// <summary>
        /// Check if the two object are equals using the provided compare function
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject"></param>
        /// <param name="checkAgainst"></param>
        /// <param name="valuesToCompareWith"></param>
        /// <returns></returns>
        public static bool EqualsTo<T>(this T subject, T checkAgainst, Func<T, T, bool> valuesToCompareWith)
            => subject != null && valuesToCompareWith(subject, checkAgainst);

    }
}

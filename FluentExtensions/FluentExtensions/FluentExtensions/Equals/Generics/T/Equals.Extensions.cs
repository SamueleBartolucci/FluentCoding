using System.Linq;
using System.Runtime.CompilerServices;

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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EqualsToAny<T>(this T subject, params T[] valuesToCompareWith)
            => subject != null && valuesToCompareWith.Any(domainValue => subject.Equals(domainValue));
    }
}

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
        public static async Task<bool> EqualsToAnyAsync<T>(this Task<T> subject, params T[] valuesToCompareWith)
            => (await subject).EqualsToAny(valuesToCompareWith);
    }
}

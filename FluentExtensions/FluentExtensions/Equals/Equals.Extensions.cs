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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding
{
    public static class EqualsExtensions
    {
        public static bool EqualsToAny<T>(this T _, params T[] domainsToCompare)
            => _.IsNullOrEquivalent() ? false : domainsToCompare.Any(domainValue => _.Equals(domainValue));


        public static bool EqualsToAny<T>(this T _, Func<T, T, bool> equalityComparison, params T[] domainsToCompare)
            => _.IsNullOrEquivalent() ? false : domainsToCompare.Any(domainValue => _.EqualsTo(domainValue, equalityComparison));//equalityComparison(_, domainValue));

        public static bool EqualsTo<T>(this T _, T checkAgainst, Func<T, T, bool> equalityComparison)
            => _.IsNullOrEquivalent() ? false : equalityComparison(_, checkAgainst);
                

        public static bool EquivalentToAny<T, K>(this T _, Func<T, K, bool> equivalentComparison, params K[] domainsToCompare)
            => _.IsNullOrEquivalent() ? false : domainsToCompare.Any(domainValue => _.EquivalentTo(domainValue, equivalentComparison));//equalityComparison(_, domainValue));

        public static bool EquivalentTo<T, K>(this T _, K checkAgainst, Func<T, K, bool> equalityComparison)
            => _.IsNullOrEquivalent() ? false : equalityComparison(_, checkAgainst);
    }
}

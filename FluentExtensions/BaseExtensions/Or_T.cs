using System;

namespace FluentCoding
{
    public static class Or_T
    {
        public static T Or<T>(this T leftValue, T orRightValue, bool chooseRight = false)
            => (leftValue.IsNullOrDefault() || chooseRight) ? orRightValue : leftValue;

        public static T Or<T>(this T _, T orReplacement, Func<T, bool> chooseRightWhen)
            => _.Or(orReplacement, chooseRightWhen(_));

        public static T Or<T>(this T _, T orReplacement, Func<bool> chooseRightWhen)
            => _.Or(orReplacement, chooseRightWhen());
    }
}
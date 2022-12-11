using System;

namespace FluentExtensions
{
    public static class OrExtensions
    {
        public static T Or<T>(this T leftValue, T orRightValue, bool leftHasPriorityWhenNotDefault = true)
            => (!leftValue.IsNullOrDefault() && leftHasPriorityWhenNotDefault) ? leftValue : orRightValue;

        public static T Or<T>(this T _, T orReplacement, Func<T, bool> chooseRightWhen)
            => _.Or(orReplacement, leftHasPriorityWhenNotDefault: !chooseRightWhen(_));
    }
}
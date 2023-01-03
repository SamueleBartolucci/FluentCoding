using System;

namespace FluentCoding
{
    public static class OrExtensions
    {
        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null and chooseRight is false
        /// white spaces strings only are considered nullOrDefault
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValue"></param>
        /// <param name="chooseRight"></param>
        /// <returns></returns>
        public static T Or<T>(this T leftValue, T orRightValue, bool chooseRight = false)
            => (leftValue.IsNullOrEquivalent() || chooseRight) ? orRightValue : leftValue;

        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null and chooseRightWhen function with input left and right values is false
        /// white spaces strings only are considered nullOrDefault
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_"></param>
        /// <param name="orReplacement"></param>
        /// <param name="chooseRightWhen"></param>
        /// <returns></returns>
        public static T Or<T>(this T _, T orReplacement, Func<T, T, bool> chooseRightWhen)
            => _.Or(orReplacement, chooseRightWhen(_, orReplacement));

        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null and chooseRightWhen function with input left value is false
        /// white spaces strings only are considered nullOrDefault
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_"></param>
        /// <param name="orReplacement"></param>
        /// <param name="chooseRightWhen"></param>
        /// <returns></returns>
        public static T Or<T>(this T _, T orReplacement, Func<T, bool> chooseRightWhen)
            => _.Or(orReplacement, chooseRightWhen(_));

        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null and chooseRightWhen is false
        /// white spaces strings only are considered nullOrDefault
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValue"></param>
        /// <param name="chooseRight"></param>
        /// <returns></returns>
        public static T Or<T>(this T _, T orReplacement, Func<bool> chooseRightWhen)
            => _.Or(orReplacement, chooseRightWhen());
    }
}
using System;

namespace FluentCoding
{
    public static partial class OrExtensions
    {
        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null and chooseRight bool is false
        /// Empty string is considered NOT null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValueFromFunc"></param>
        /// <param name="chooseRight"></param>
        /// <returns></returns>
        public static T Or<T>(this T leftValue, Func<T> orRightValueFromFunc, bool chooseRight = false)
            => (leftValue == null || chooseRight) ? orRightValueFromFunc() : leftValue;

        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null and chooseRightWhen() is false
        /// Empty string is considered NOT null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValueFromFunc"></param>
        /// <param name="chooseRightWhen"></param>
        /// <returns></returns>
        public static T Or<T>(this T leftValue, Func<T> orRightValueFromFunc, Func<bool> chooseRightWhen)
            => leftValue.Or(orRightValueFromFunc, chooseRightWhen());

        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null and chooseRightWhen(leftValue) is false
        /// Empty string is considered NOT null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValueFromFunc"></param>
        /// <param name="chooseRightWhen"></param>
        /// <returns></returns>
        public static T Or<T>(this T leftValue, Func<T> orRightValueFromFunc, Func<T, bool> chooseRightWhen)
            => leftValue.Or(orRightValueFromFunc, chooseRightWhen(leftValue));
    }
}
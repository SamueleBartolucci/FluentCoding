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
        /// <param name="orRightValue"></param>
        /// <param name="chooseRight"></param>
        /// <returns></returns>
        public static T Or<T>(this Optional<T> leftValue, T orRightValue, bool chooseRight = false)
            => (leftValue == null || leftValue.IsNone() || chooseRight) ? orRightValue : leftValue.Subject;

        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null and chooseRightWhen() is false
        /// Empty string is considered NOT null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValue"></param>
        /// <param name="chooseRightWhen"></param>
        /// <returns></returns>
        public static T Or<T>(this Optional<T> leftValue, T orRightValue, Func<bool> chooseRightWhen)
            => leftValue.Or(orRightValue, chooseRightWhen());

        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null and chooseRightWhen(leftValue) is false
        /// Empty string is considered NOT null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValue"></param>
        /// <param name="chooseRightWhen"></param>
        /// <returns></returns>
        public static T Or<T>(this Optional<T> leftValue, T orRightValue, Func<Optional<T>, bool> chooseRightWhen)
            => leftValue.Or(orRightValue, chooseRightWhen(leftValue));

        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null and chooseRightWhen(leftValue, orRightValue) is false
        /// Empty string is considered NOT null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValue"></param>
        /// <param name="chooseRightWhen"></param>
        /// <returns></returns>
        public static T Or<T>(this Optional<T> leftValue, T orRightValue, Func<Optional<T>, T, bool> chooseRightWhen)
            => leftValue.Or(orRightValue, chooseRightWhen(leftValue, orRightValue));

       

    }
}
using System;

namespace FluentCoding
{
    public static partial class OrIsEmptyExtensions
    {
        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null or empty and IsSome and and chooseRight bool is false
        /// Empty string is considered null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValue"></param>
        /// <param name="chooseRight"></param>
        /// <returns></returns>
        public static string OrOptnIsEmpty(this Optional<string> leftValue, string orRightValue, bool chooseRight = false)
            => leftValue.IsNone() || string.IsNullOrEmpty(leftValue.Subject) || chooseRight ? orRightValue : leftValue.Subject;

        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null or empty and IsSome and and chooseRightWhen(leftValue, orRightValue) is false
        /// Empty string is considered null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValue"></param>
        /// <param name="chooseRightWhen"></param>
        /// <returns></returns>
        public static string OrOptnIsEmpty(this Optional<string> leftValue, string orRightValue, Func<string, string, bool> chooseRightWhen)
           => leftValue.OrOptnIsEmpty(orRightValue, leftValue.IsNone() || chooseRightWhen(leftValue.Subject, orRightValue));

        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null or empty and IsSome and and chooseRightWhen(leftValue) is false
        /// Empty string is considered null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValue"></param>
        /// <param name="chooseRightWhen"></param>
        /// <returns></returns>
        public static string OrOptnIsEmpty(this Optional<string> leftValue, string orRightValue, Func<string, bool> chooseRightWhen)
            => leftValue.OrOptnIsEmpty(orRightValue, leftValue.IsNone() || chooseRightWhen(leftValue.Subject));

        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null or empty and IsSome and and chooseRightWhen() is false
        /// Empty string is considered null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValue"></param>
        /// <param name="chooseRightWhen"></param>
        /// <returns></returns>
        public static string OrOptnIsEmpty(this Optional<string> leftValue, string orRightValue, Func<bool> chooseRightWhen)
           => leftValue.OrOptnIsEmpty(orRightValue, chooseRightWhen());
    }
}
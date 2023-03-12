using System;

namespace FluentCoding
{
    public static partial class OrIsEmptyExtensions
    {
        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null or empty and chooseRight bool is false
        /// Empty string is considered null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValue"></param>
        /// <param name="chooseRight"></param>
        /// <returns></returns>
        public static string OrIsEmpty(this string leftValue, string orRightValue, bool chooseRight = false)
            =>  string.IsNullOrEmpty(leftValue) || chooseRight ? orRightValue : leftValue;

        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null or empty and chooseRightWhen(leftValue, orRightValue) is false
        /// Empty string is considered null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValue"></param>
        /// <param name="chooseRightWhen"></param>
        /// <returns></returns>
        public static string OrIsEmpty(this string leftValue, string orRightValue, Func<string, string, bool> chooseRightWhen)
           => leftValue.OrIsEmpty(orRightValue, chooseRightWhen(leftValue, orRightValue));

        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null or empty and chooseRightWhen(leftValue) is false
        /// Empty string is considered null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValue"></param>
        /// <param name="chooseRightWhen"></param>
        /// <returns></returns>
        public static string OrIsEmpty(this string leftValue, string orRightValue, Func<string, bool> chooseRightWhen)
            => leftValue.OrIsEmpty(orRightValue, chooseRightWhen(leftValue));

        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null or empty and chooseRightWhen() is false
        /// Empty string is considered null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValue"></param>
        /// <param name="chooseRightWhen"></param>
        /// <returns></returns>
        public static string OrIsEmpty(this string leftValue, string orRightValue, Func<bool> chooseRightWhen)
           => leftValue.OrIsEmpty(orRightValue, chooseRightWhen());
    }
}
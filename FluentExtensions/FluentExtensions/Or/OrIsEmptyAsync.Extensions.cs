using System;
using System.Threading.Tasks;

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
        public static async Task<string> OrIsEmptyAsync(this Task<string> leftValue, string orRightValue, bool chooseRight = false)
            => (await leftValue).OrIsEmpty(orRightValue, chooseRight);

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
        public static async Task<string> OrIsEmptyAsync(this Task<string> leftValue, string orRightValue, Func<string, string, bool> chooseRightWhen)
           => (await leftValue).OrIsEmpty(orRightValue, chooseRightWhen);

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
        public static async Task<string> OrIsEmptyAsync(this Task<string> leftValue, string orRightValue, Func<string, bool> chooseRightWhen)
            => (await leftValue).OrIsEmpty(orRightValue, chooseRightWhen);

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
        public static async Task<string> OrIsEmptyAsync(this Task<string> leftValue, string orRightValue, Func<bool> chooseRightWhen)
           => (await leftValue).OrIsEmpty(orRightValue, chooseRightWhen);
    }
}
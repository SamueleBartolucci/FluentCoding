using System;
using System.Threading.Tasks;

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
        public static async Task<string> OrOptnIsEmptyAsync(this Task<Optional<string>> leftValue, string orRightValue, bool chooseRight = false)
            => (await leftValue).OrOptnIsEmpty(orRightValue, chooseRight);

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
        public static async Task<string> OrOptnIsEmptyAsync(this Task<Optional<string>> leftValue, string orRightValue, Func<string, string, bool> chooseRightWhen)
           => (await leftValue).OrOptnIsEmpty(orRightValue, chooseRightWhen);

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
        public static async Task<string> OrOptnIsEmptyAsync(this Task<Optional<string>> leftValue, string orRightValue, Func<string, bool> chooseRightWhen)
            => (await leftValue).OrOptnIsEmpty(orRightValue, chooseRightWhen);

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
        public static async Task<string> OrOptnIsEmptyAsync(this Task<Optional<string>> leftValue, string orRightValue, Func<bool> chooseRightWhen)
           => (await leftValue).OrOptnIsEmpty(orRightValue, chooseRightWhen);
    }
}
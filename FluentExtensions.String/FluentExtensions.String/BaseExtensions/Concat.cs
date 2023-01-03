using System.Collections.Generic;
using System.Linq;

namespace FluentCoding.String
{
    
    public static class Concat
    {
        /// <summary>
        /// When the input is not null or default, is merged with the left and right values
        /// Left or Right when only whitespaces are trimmed
        /// </summary>
        /// <param name="_"></param>
        /// <param name="appendLeft"></param>
        /// <param name="appendRight"></param>
        /// <returns></returns>
        public static string ConcatWhenWithValue(this string _, string appendLeft, string appendRight, IsNullWhen subjectOptions = IsNullWhen.NullOrEmpty)
        {
            var optn = subjectOptions.ToNullOptions();

            return _.When(!_.IsNullOrEquivalent(optn))
                    .Then(sbj => string.Concat(appendLeft, sbj, appendRight));
        }






        /// <summary>
        ///  When the subject is not null or default, append the subject string at the start of each string from the domain
        /// </summary>
        /// <param name="_"></param>
        /// <param name="rightStrings"></param>
        /// <param name="optionalSeparator"></param>
        /// <returns></returns>
        public static IEnumerable<string> ConcatLeftToAll(this string _, IEnumerable<string> rightStrings, string optionalSeparator = "", IsNullWhen subjectOptions = IsNullWhen.NullOrEmpty)
           => rightStrings.Select(rightString => _.ConcatWhenWithValue(string.Empty, $"{optionalSeparator}{rightString}", subjectOptions));

        /// <summary>
        ///  When the subject is not null or default, append the subject string at the end of each string from the domain
        /// </summary>
        /// <param name="_"></param>
        /// <param name="leftStrings"></param>
        /// <param name="optionalSeparator"></param>
        /// <returns></returns>
        public static IEnumerable<string> ConcatRightToAll(this string _, IEnumerable<string> leftStrings, string optionalSeparator = "", IsNullWhen subjectOptions = IsNullWhen.NullOrEmpty)
           => leftStrings.Select(leftString => _.ConcatWhenWithValue($"{leftString}{optionalSeparator}", string.Empty, subjectOptions));

        /// <summary>
        /// When the subject is not null or default, append the subject on the right of the specified string
        /// </summary>
        /// <param name="_"></param>
        /// <param name="leftString"></param>
        /// <returns></returns>
        public static string ConcatRightToWhenWithValue(this string _, string leftString, IsNullWhen subjectOptions = IsNullWhen.NullOrEmpty)
            => _.ConcatWhenWithValue(leftString, string.Empty, subjectOptions);

        /// <summary>
        /// When the subject is not null or default, append the subject on the left of the specified string
        /// </summary>
        /// <param name="_"></param>
        /// <param name="appendAfter"></param>
        /// <returns></returns>
        public static string ConcatLeftToWhenWithValue(this string s, string rightString, IsNullWhen subjectOptions = IsNullWhen.NullOrEmpty)
            => s.ConcatWhenWithValue(string.Empty, rightString, subjectOptions);
    }
}
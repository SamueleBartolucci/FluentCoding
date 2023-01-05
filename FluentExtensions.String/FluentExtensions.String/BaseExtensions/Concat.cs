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
        /// <param name="subject"></param>
        /// <param name="appendLeft"></param>
        /// <param name="appendRight"></param>
        /// <param name="subjectNullWhen"></param>
        /// <returns></returns>
        public static string ConcatWhenWithValue(this string subject, string appendLeft, string appendRight, StringIsNullWhenEnum subjectNullWhen = StringIsNullWhenEnum.NullOrEmpty)
        {
            return subject.When(!subject.IsNullOrEquivalent(_ => _.StringIsNullWhen = subjectNullWhen))
                    .Then(sbj => string.Concat(appendLeft, sbj, appendRight));
        }






        /// <summary>
        ///  When the subject is not null or default, append the subject string at the start of each string from the domain
        /// </summary>
        /// <param name="_"></param>
        /// <param name="rightStrings"></param>
        /// <param name="optionalSeparator"></param>
        /// <param name="subjectNullWhen"></param>
        /// <returns></returns>
        public static IEnumerable<string> ConcatLeftToAll(this string _, IEnumerable<string> rightStrings, string optionalSeparator = "", StringIsNullWhenEnum subjectNullWhen = StringIsNullWhenEnum.NullOrEmpty)
           => rightStrings.Select(rightString => _.ConcatWhenWithValue(string.Empty, $"{optionalSeparator}{rightString}", subjectNullWhen));

        /// <summary>
        /// When the subject is not null or default, append the subject string at the end of each string from the domain
        /// </summary>
        /// <param name="_"></param>
        /// <param name="leftStrings"></param>
        /// <param name="optionalSeparator"></param>
        /// <param name="subjectNullWhen"></param>
        /// <returns></returns>
        public static IEnumerable<string> ConcatRightToAll(this string _, IEnumerable<string> leftStrings, string optionalSeparator = "", StringIsNullWhenEnum subjectNullWhen = StringIsNullWhenEnum.NullOrEmpty)
           => leftStrings.Select(leftString => _.ConcatWhenWithValue($"{leftString}{optionalSeparator}", string.Empty, subjectNullWhen));

        /// <summary>
        /// When the subject is not null or default, append the subject string at the end of each string from the domain
        /// </summary>
        /// <param name="_"></param>
        /// <param name="leftString"></param>
        /// <param name="subjectNullWhen"></param>
        /// <returns></returns>
        public static string ConcatRightToWhenWithValue(this string _, string leftString, StringIsNullWhenEnum subjectNullWhen = StringIsNullWhenEnum.NullOrEmpty)
            => _.ConcatWhenWithValue(leftString, string.Empty, subjectNullWhen);

        /// <summary>
        /// When the subject is not null or default, append the subject on the left of the specified string
        /// </summary>
        /// <param name="s"></param>
        /// <param name="rightString"></param>
        /// <param name="subjectNullWhen"></param>
        /// <returns></returns>
        public static string ConcatLeftToWhenWithValue(this string s, string rightString, StringIsNullWhenEnum subjectNullWhen = StringIsNullWhenEnum.NullOrEmpty)
            => s.ConcatWhenWithValue(string.Empty, rightString, subjectNullWhen);
    }
}
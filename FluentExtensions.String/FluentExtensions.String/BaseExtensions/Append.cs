namespace FluentCoding.String
{
    public static class Append
    {
        /// <summary>
        /// Append the subject string at the start of each string from the domain
        /// </summary>
        /// <param name="_"></param>
        /// <param name="stringsToAppendBefore"></param>
        /// <param name="optionalSeparator"></param>
        /// <returns></returns>
        public static IEnumerable<string> AppendBeforeToAll(this string _, IEnumerable<string> stringsToAppendBefore, string optionalSeparator = "")
           => stringsToAppendBefore.Select(beforeString => string.Concat(beforeString, optionalSeparator, _));

        /// <summary>
        /// Append the subject string at the end of each string from the domain
        /// </summary>
        /// <param name="_"></param>
        /// <param name="stringsToAppendAfter"></param>
        /// <param name="optionalSeparator"></param>
        /// <returns></returns>
        public static IEnumerable<string> AppendAfterToAll(this string _, IEnumerable<string> stringsToAppendAfter, string optionalSeparator = "")
           => stringsToAppendAfter.Select(afterString => string.Concat(_, optionalSeparator, afterString));

        /// <summary>
        /// When the subject is not null or default, append after the subject the specified string
        /// </summary>
        /// <param name="_"></param>
        /// <param name="stringToAppendAfter"></param>
        /// <returns></returns>
        public static string AppendAfterWhenWithValue(this string _, string stringToAppendAfter)
            => _.ConcatWhenWithValue("", stringToAppendAfter);

        /// <summary>
        /// When the subject is not null or default, append before the subject the specified string
        /// </summary>
        /// <param name="_"></param>
        /// <param name="appendAfter"></param>
        /// <returns></returns>
        public static string AppendBeforeWhenWithValue(this string s, string stringToAppendBefore)
            => s.ConcatWhenWithValue(stringToAppendBefore, "");
    }
}
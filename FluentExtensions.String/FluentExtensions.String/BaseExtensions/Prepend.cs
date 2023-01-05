
using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentCoding.String
{
    public static class PrependWhenExtensions
    {
        /// <summary>
        /// Add the stringToPrepend as first element of the IEnumerable subject when doPrepend is true
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="stringToPrepend"></param>
        /// <param name="doPrepend"></param>
        /// <returns></returns>
        public static IEnumerable<string> PrependWhen(this IEnumerable<string> subject, string stringToPrepend, bool doPrepend)
          => subject.When(doPrepend).Then(sbj => sbj.Prepend(stringToPrepend));

        /// <summary>
        /// Add the stringToPrepend as first element of the IEnumerable subject when doPrependWhen() is true
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="stringToPrepend"></param>
        /// <param name="doPrependWhen"></param>
        /// <returns></returns>
        public static IEnumerable<string> PrependWhen(this IEnumerable<string> subject, string stringToPrepend, Func<bool> doPrependWhen)
          => subject.PrependWhen(stringToPrepend, doPrependWhen());
    }
}
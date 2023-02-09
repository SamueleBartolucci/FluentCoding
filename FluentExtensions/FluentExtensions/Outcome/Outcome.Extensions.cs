using System;
using System.Linq;
using System.Security.Cryptography;

namespace FluentCoding
{
    public static partial class OutcomeExtensions
    {
        /// <summary>
        /// Convert the subject into the succesfull Outcome with the subject as Success
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="F"></typeparam>
        /// <param name="_"></param>
        /// <returns></returns>
        public static Outcome<S, F> ToSuccessOutcome<S, F>(this S _) => Outcome<S, F>.ToSuccess(_);

        /// <summary>
        /// Convert the subject into a not succesfull Outcome with the subject as Failure
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="F"></typeparam>
        /// <param name="_"></param>
        /// <returns></returns>
        public static Outcome<S, F> ToFailureOutcome<S, F>(this F _) => Outcome<S, F>.ToFailure(_);

    }

}
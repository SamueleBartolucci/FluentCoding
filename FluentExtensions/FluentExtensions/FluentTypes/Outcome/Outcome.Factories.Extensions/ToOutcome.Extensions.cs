using System;

namespace FluentCoding
{
    public static partial class OutcomeExtensions
    {
        /// <summary>
        /// Convert the subject into the successful Outcome with the subject as Success
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="F"></typeparam>
        /// <param name="_"></param>
        /// <returns></returns>
        public static Outcome<S, F> ToSuccessOutcome<S, F>(this S _) => Outcome<S, F>.ToSuccess(_);

        /// <summary>
        /// Convert the subject into a not successful Outcome with the subject as Failure
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="F"></typeparam>
        /// <param name="_"></param>
        /// <returns></returns>
        public static Outcome<S, F> ToFailureOutcome<S, F>(this F _) => Outcome<S, F>.ToFailure(_);


        /// <summary>
        /// Convert the subject into an Outcome
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="F"></typeparam>
        /// <param name="_"></param>
        /// <param name="isFailureWhen"></param>
        /// <param name="failureValue"></param>
        /// <returns></returns>
        public static Outcome<S, F> ToOutcome<S, F>(this S _, Func<bool> isFailureWhen, F failureValue) => Outcome<S, F>.ToOutcome(_, isFailureWhen, failureValue);

        /// <summary>
        /// Convert the subject into an Outcome
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="F"></typeparam>
        /// <param name="_"></param>
        /// <param name="isFailureWhen"></param>
        /// <param name="failureValue"></param>
        /// <returns></returns>
        public static Outcome<S, F> ToOutcome<S, F>(this S _, Func<S, bool> isFailureWhen, F failureValue) => Outcome<S, F>.ToOutcome(_, isFailureWhen, failureValue);

    }

}
using System;

namespace FluentCoding
{
    public static partial class OutcomeExtensions
    {
        /// <summary>
        /// Convert the subject into an Outcome
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="F"></typeparam>
        /// <param name="optionalSubject"></param>
        /// <param name="onNone"></param>
        /// <returns></returns>
        public static Outcome<S, F> ToOutcome<S, F>(this Optional<S> optionalSubject, F onNone)
            => optionalSubject.WhenOptn(optionalSubject.IsSome())
                .Then(someValue => someValue.Subject.ToSuccessOutcome<S, F>(),
                      nome => onNone.ToFailureOutcome<S, F>());

        /// <summary>
        /// Convert the subject into an Outcome
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="F"></typeparam>
        /// <param name="optionalSubjectect"></param>
        /// <param name="onNone"></param>
        /// <returns></returns>
        public static Outcome<S, F> ToOutcome<S, F>(this Optional<S> optionalSubjectect, Func<F> onNone)
            => optionalSubjectect.WhenOptn(optionalSubjectect.IsSome())
                .Then(someValue => someValue.Subject.ToSuccessOutcome<S, F>(),
                      nome => onNone().ToFailureOutcome<S, F>());


    }

}
using System;

namespace FluentCoding
{
    /// <summary>
    /// Outcome class (a simplified version of the railways functional Either)
    /// The class contains the Success Value (or Right) or the Fail Value (or Left) of a function
    /// </summary>
    /// <typeparam name="S"></typeparam>    
    /// <typeparam name="F"></typeparam>
    public partial class Outcome<S, F> : ResultContext
    {
        /// <summary>
        /// Successful result available when status is IsSuccessful=true
        /// </summary>
        public S Success { get; set; }

        /// <summary>
        /// Failure result available when status is IsSuccessful=true
        /// </summary>
        public F Failure { get; set; }

        public static implicit operator Outcome<S, F>(S input) => ToSuccess(input);
        public static implicit operator Outcome<S, F>(F input) => ToFailure(input);

        //internal Outcome(bool successStatus) : base() { IsSuccessful = successStatus; }
        public Outcome(S successValue) : base(true) { Success = successValue; Failure = default; }
        public Outcome(F failureValue) : base(false) { Success = default; Failure = failureValue; }


        /// <summary>
        /// Create a success/failure outcome based on the predicate whenIsFailure
        /// </summary>
        /// <param name="successValue"></param>
        /// <param name="isFailureWhen"></param>
        /// <param name="failureValue"></param>
        /// <returns></returns>
        public static Outcome<S, F> ToOutcome(S successValue, Func<bool> isFailureWhen, F failureValue)
            => isFailureWhen() ? ToFailure(failureValue) : ToSuccess(successValue);

        /// <summary>
        /// Create a success/failure outcome based on the predicate whenIsFailure
        /// </summary>
        /// <param name="successValue"></param>
        /// <param name="isFailureWhen"></param>
        /// <param name="failureValue"></param>
        /// <returns></returns>
        public static Outcome<S, F> ToOutcome(S successValue, Func<S, bool> isFailureWhen, F failureValue)
            => isFailureWhen(successValue) ? ToFailure(failureValue) : ToSuccess(successValue);

        /// <summary>
        /// Return a successful outcome
        /// </summary>
        /// <param name="successValue"></param>
        /// <returns></returns>
        public static Outcome<S, F> ToSuccess(S successValue)
            => new Outcome<S, F>(successValue);

        /// <summary>
        /// Return a failure outcome
        /// </summary>
        /// <param name="failureValue"></param>
        /// <returns></returns>
        public static Outcome<S, F> ToFailure(F failureValue)
            => new Outcome<S, F>(failureValue);


        /// <summary>
        /// Apply a function 'S -> Outcome&lt;S1, F1&gt;' or 'F -> Outcome&lt;S1, F1&gt;' to the Outcome based on the IsSuccessful status
        /// Return a new Outcome&lt;S1, F1&gt;        
        /// </summary>
        /// <typeparam name="S1"></typeparam>
        /// <typeparam name="F1"></typeparam>
        /// <param name="doWhenSuccess"></param>
        /// <param name="doWhenFailure"></param>
        /// <returns></returns>
        public Outcome<S1, F1> Bind<S1, F1>(Func<S, Outcome<S1, F1>> doWhenSuccess, Func<F, Outcome<S1, F1>> doWhenFailure)
            => IsSuccessful ? doWhenSuccess(Success) : doWhenFailure(Failure);


        /// <summary>
        /// Apply a function "S -> Outcome&lt;S1, F&gt;" to the Success  field when the status IsSuccessful = true
        /// Return a new Outcome&lt;S1, F&gt;
        /// </summary>
        /// <typeparam name="S1"></typeparam>
        /// <param name="doWhenSuccess"></param>
        /// <returns></returns>
        public Outcome<S1, F> BindSuccess<S1>(Func<S, Outcome<S1, F>> doWhenSuccess)
            => IsSuccessful ? doWhenSuccess(Success) :
                             Outcome<S1, F>.ToFailure(Failure);

        /// <summary>
        /// Apply a function "F -> Outcome&lt;S, F1&gt;" to the Failure field when the status IsSuccessful = false
        /// Return a new Outcome&lt;S, F1&gt;
        /// </summary>
        /// <typeparam name="F1"></typeparam>
        /// <param name="doWhenFail"></param>
        /// <returns></returns>
        public Outcome<S, F1> BindFailure<F1>(Func<F, Outcome<S, F1>> doWhenFail)
            => !IsSuccessful ? doWhenFail(Failure) :
                              Outcome<S, F1>.ToSuccess(Success);

        /// <summary>
        /// Apply a function "S -> S1" or "F -> F1" to the Outcome based on the IsSuccessful status
        /// Return a new Outcome&lt;S1, F1&gt;
        /// </summary>
        /// <typeparam name="S1"></typeparam>
        /// <typeparam name="F1"></typeparam>
        /// <param name="doWhenSuccess"></param>
        /// <param name="doWhenFail"></param>
        /// <returns></returns>
        public Outcome<S1, F1> Map<S1, F1>(Func<S, S1> doWhenSuccess, Func<F, F1> doWhenFail)
           => IsSuccessful ? Outcome<S1, F1>.ToSuccess(doWhenSuccess(Success)) :
                            Outcome<S1, F1>.ToFailure(doWhenFail(Failure));

        /// <summary>
        /// Apply a function "F -> F1" to the Failure field when the status IsSuccessful = false
        /// Return a new Outcome&lt;S, F1&gt;
        /// </summary>
        /// <typeparam name="F1"></typeparam>
        /// <param name="doWhenFail"></param>
        /// <returns></returns>
        public Outcome<S, F1> MapFailure<F1>(Func<F, F1> doWhenFail)
            => !IsSuccessful ? Outcome<S, F1>.ToFailure(doWhenFail(Failure)) :
                              Outcome<S, F1>.ToSuccess(Success);

        /// <summary>
        /// Apply a function "S -> S1" to the Success field when the status IsSuccessful = true
        /// Return a new Outcome&lt;S1, F&gt;
        /// </summary>
        /// <typeparam name="S1"></typeparam>
        /// <param name="doWhenSuccess"></param>
        /// <returns></returns>
        public Outcome<S1, F> MapSuccess<S1>(Func<S, S1> doWhenSuccess)
            => IsSuccessful ? Outcome<S1, F>.ToSuccess(doWhenSuccess(Success)) :
                             Outcome<S1, F>.ToFailure(Failure);


        /// <summary>
        /// Apply an action on the Failure field when the status IsSuccessful = false
        /// </summary>
        /// <param name="doWhenFail"></param>
        /// <returns></returns>
        public Outcome<S, F> WhenFailure(Action<F> doWhenFail)
            => this.When(!IsSuccessful)
                   .Then(failureOutcome => doWhenFail(failureOutcome.Failure));

        /// <summary>
        /// Apply an action on the Success field when the status IsSuccessful = true
        /// </summary>
        /// <param name="doWhenSuccess"></param>
        /// <returns></returns>
        public Outcome<S, F> WhenSuccess(Action<S> doWhenSuccess)
            => this.When(IsSuccessful)
                   .Then(successOutcome => doWhenSuccess(successOutcome.Success));

        /// <summary>
        /// Unwrap the Outcome using the Map success/fail based on the IsSuccessful status
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mapOnSuccess"></param>
        /// <param name="mapOnFail"></param>
        /// <returns></returns>
        public T Match<T>(Func<S, T> mapOnSuccess, Func<F, T> mapOnFail)
           => IsSuccessful ? mapOnSuccess(Success) : mapOnFail(Failure);
    }
}

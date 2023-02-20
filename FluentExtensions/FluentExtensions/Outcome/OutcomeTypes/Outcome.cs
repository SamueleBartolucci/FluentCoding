using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FluentCoding
{
    /// <summary>
    /// Outcome class (a simplified version of the railways functional Either)
    /// The class contains the Success Value (or Right) or the Fail Value (or Left) of a function
    /// </summary>
    /// <typeparam name="S"></typeparam>    
    /// <typeparam name="F"></typeparam>
    public partial class Outcome<S, F> : FluentContext<S>
    {
        internal Outcome(bool successStatus) : base() { IsSuccessful = successStatus; }
        internal Outcome(S successValue) : this(true) { Success = successValue; }
        internal Outcome(F failureValue) : this(false) { Failure = failureValue; }

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
        /// Successful result available when status is IsSuccessful=true
        /// </summary>
        public S Success { get; set; }

        /// <summary>
        /// Failure result available when status is IsSuccessful=true
        /// </summary>
        public F Failure { get; set; }

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
        /// Apply a function "S -> Outcome&lt;S1, F&gt;"  to the Success value when IsSuccsful otherwise it just return the Outcome with the Failure
        /// Return a new Outcome&lt;S1, F&gt;
        /// </summary>
        /// <typeparam name="S1"></typeparam>
        /// <param name="doWhenSuccess"></param>
        /// <returns></returns>
        public Outcome<S1, F> BindSuccess<S1>(Func<S, Outcome<S1, F>> doWhenSuccess)
            => IsSuccessful ? doWhenSuccess(Success) :
                             Outcome<S1, F>.ToFailure(Failure);

        /// <summary>
        /// Apply a function "F -> Outcome&lt;S, F1&gt;"  to the Failure value when not IsSuccsful otherwise it just return the Outcome with the Success
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
        /// Apply a function "F -> F1" to change the Failure result only when not IsSucceful
        /// Return a new Outcome&lt;S, F1&gt;
        /// </summary>
        /// <typeparam name="F1"></typeparam>
        /// <param name="doWhenFail"></param>
        /// <returns></returns>
        public Outcome<S, F1> MapFailure<F1>(Func<F, F1> doWhenFail)
            => !IsSuccessful ? Outcome<S, F1>.ToFailure(doWhenFail(Failure)) : 
                              Outcome<S, F1>.ToSuccess(Success);

        /// <summary>
        /// Apply a function "S -> S1" to the Success result  only when IsSucceful
        /// Return a new Outcome&lt;S1, F&gt;
        /// </summary>
        /// <typeparam name="S1"></typeparam>
        /// <param name="doWhenSuccess"></param>
        /// <returns></returns>
        public Outcome<S1, F> MapSuccess<S1>(Func<S, S1> doWhenSuccess)
            => IsSuccessful ? Outcome<S1, F>.ToSuccess(doWhenSuccess(Success)) :
                             Outcome<S1, F>.ToFailure(Failure);
    }
}

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
        internal Outcome(bool successStatus) : base() { IsSuccesful = successStatus; }
        internal Outcome(S successValue) : base() { Success = successValue; }
        internal Outcome(F failureValue) : base() { Failure = failureValue; }

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
        /// Successful result
        /// </summary>
        public S Success { get; set; }

        /// <summary>
        /// Failure result
        /// </summary>
        public F Failure { get; set; }      

        /// <summary>
        /// Apply a function to the Success or the Failure value based on the status
        /// Return a new Outcome
        /// </summary>
        /// <typeparam name="S1"></typeparam>
        /// <typeparam name="F1"></typeparam>
        /// <param name="doWhenSuccess"></param>
        /// <param name="doWhenFailure"></param>
        /// <returns></returns>
        public Outcome<S1, F1> Bind<S1, F1>(Func<S, Outcome<S1, F1>> doWhenSuccess, Func<F, Outcome<S1, F1>> doWhenFailure) 
            => IsSuccesful ? doWhenSuccess(Success) : doWhenFailure(Failure);


        /// <summary>
        /// Apply a function to the Success only when successful
        /// Return a new Outcome
        /// </summary>
        /// <typeparam name="S1"></typeparam>
        /// <param name="doWhenSuccess"></param>
        /// <returns></returns>
        public Outcome<S1, F> BindSuccess<S1>(Func<S, Outcome<S1, F>> doWhenSuccess)
            => IsSuccesful ? doWhenSuccess(Success) :
                             Outcome<S1, F>.ToFailure(Failure);

        /// <summary>
        /// Apply a function to the Success only when successful        
        /// Return a new Outcome
        /// </summary>
        /// <typeparam name="F1"></typeparam>
        /// <param name="doWhenFail"></param>
        /// <returns></returns>
        public Outcome<S, F1> BindFailure<F1>(Func<F, Outcome<S, F1>> doWhenFail)
            => !IsSuccesful ? doWhenFail(Failure) : 
                              Outcome<S, F1>.ToSuccess(Success);

        /// <summary>
        /// Apply a function to change the Success or Falure result based on the succesful status
        /// </summary>
        /// <typeparam name="S1"></typeparam>
        /// <typeparam name="F1"></typeparam>
        /// <param name="doWhenSuccess"></param>
        /// <param name="doWhenFail"></param>
        /// <returns></returns>
        public Outcome<S1, F1> Map<S1, F1>(Func<S, S1> doWhenSuccess, Func<F, F1> doWhenFail)
           => IsSuccesful ? Outcome<S1, F1>.ToSuccess(doWhenSuccess(Success)) :
                            Outcome<S1, F1>.ToFailure(doWhenFail(Failure));

        /// <summary>
        /// Apply a function to change the Failure result (only if status is failed)
        /// Return a new Outcome
        /// </summary>
        /// <typeparam name="F1"></typeparam>
        /// <param name="doWhenFail"></param>
        /// <returns></returns>
        public Outcome<S, F1> MapFailure<F1>(Func<F, F1> doWhenFail)
            => !IsSuccesful ? Outcome<S, F1>.ToFailure(doWhenFail(Failure)) : 
                              Outcome<S, F1>.ToSuccess(Success);

        /// <summary>
        /// Apply a function to change the Success result (only if status is succesful)
        /// Return a new Outcome
        /// </summary>
        /// <typeparam name="S1"></typeparam>
        /// <param name="doWhenSuccess"></param>
        /// <returns></returns>
        public Outcome<S1, F> MapSuccess<S1>(Func<S, S1> doWhenSuccess)
            => IsSuccesful ? Outcome<S1, F>.ToSuccess(doWhenSuccess(Success)) :
                             Outcome<S1, F>.ToFailure(Failure);
    }
}

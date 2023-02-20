using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FluentCoding
{
    /// <summary>
    /// TryCath class to wrap the try{} catch{} clause in a fluent way
    /// The class expose the status of the try 'IsSuccessful', the result of the try function 'Result' the option exception 'Error'
    /// </summary>
    /// <typeparam name="S"></typeparam>
    /// <typeparam name="R"></typeparam>
    /// <typeparam name="E"></typeparam>
    public partial class TryCatch<S, R, E> : FluentContext<S>
    {
        internal TryCatch() : base() { }

        /// <summary>
        /// result of the Try function
        /// </summary>
        public R Result { get; set; }

        /// <summary>
        /// Exception of result of the error mapping function
        /// </summary>
        public E Error { get; set; }


        internal TryCatch<S, R, E> Try(Action<S> tryTo, Func<S, Exception, E> onError)
        {
            try
            {
                tryTo(Subject);                
                IsSuccessful = true;
            }
            catch (Exception e)
            {
                IsSuccessful = false;
                Error = onError(Subject, e);
            }
            return this;
        }


        internal TryCatch<S, R, E> Try(Func<S, R> tryTo, Func<S, Exception, E> onError)
        {
            try 
            {
                Result = tryTo(Subject); 
                IsSuccessful = true; 
            }
            catch (Exception e) 
            {
                IsSuccessful = false;
                Error = onError(Subject, e);                
            }
            return this;
        }

        /// <summary>
        /// Apply a further function on the Try.Result when the Try is successfull
        /// </summary>
        /// <typeparam name="TRES"></typeparam>
        /// <param name="whenOk"></param>
        /// <returns></returns>
        public (TRES Success, TryCatch<S, R, E> TryCatch) OnSuccess<TRES>(Func<R, TRES> whenOk)
         => (whenOk.Or(GetDefaultResult<R, TRES>, !IsSuccessful)(Result), 
             this);

        /// <summary>
        /// /// Apply a further function on the Try.Error when the Try is failed
        /// </summary>
        /// <typeparam name="TERR"></typeparam>
        /// <param name="whenException"></param>
        /// <returns></returns>
        public (TERR Fail, TryCatch<S, R, E> TryCatch) OnFail<TERR>(Func<S, E, TERR> whenException)
            => (whenException.Or(GetDefaultError<S, E, TERR>, IsSuccessful)(Subject, Error),
                this);


        /// <summary>
        /// Apply a further function on the Try.Result or Try.Error based on the Try raising or not an exception
        /// return the function result 
        /// </summary>
        /// <typeparam name="TRES"></typeparam>
        /// <typeparam name="TERR"></typeparam>
        /// <param name="whenOk"></param>
        /// <param name="whenOnException"></param>
        /// <returns></returns>
        public (TRES Success, TERR Fail) Then<TRES, TERR>(Func<R, TRES> whenOk, Func<S, E, TERR> whenOnException)
            => (whenOk.Or(GetDefaultResult<R, TRES>, !IsSuccessful)(Result),  
                whenOnException.Or(GetDefaultError<S, E, TERR>, IsSuccessful)(Subject, Error));

        /// <summary>
        /// Apply a further function that change the original Type on the Try.Result or Try.Error based on the Try raising or not an exception
        /// </summary>
        /// <typeparam name="TRES"></typeparam>
        /// <param name="whenOk"></param>
        /// <param name="whenOnException"></param>
        /// <returns></returns>
        public TRES ThenMap<TRES>(Func<R, TRES> whenOk, Func<S, E, TRES> whenOnException)
            => IsSuccessful? whenOk(Result) : whenOnException(Subject, Error);


        private static B GetDefaultResult<A, B>(A subject) => default(B);
        private static  C GetDefaultError<A, B, C>(A subject, B error) => default(C);
    }
}

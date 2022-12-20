using FluentCoding.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FluentCoding
{
    public partial class TryCatch<S, R, E> : BaseContext<S>
    {
        internal TryCatch() : base() { }

        public R Result { get; set; }
        public E Error { get; set; }
        
        
        internal TryCatch<S, R, E> Try(Func<S, R> tryTo, Func<S, Exception, E> onError)
        {
            try 
            {
                Result = tryTo(Subject); 
                IsSuccesful = true; 
            }
            catch (Exception e) 
            {
                IsSuccesful = false;
                Error = onError(Subject, e);                
            }
            return this;
        }


        public (TRES Success, TryCatch<S, R, E> TryCatch) OnSuccess<TRES>(Func<R, TRES> whenOk)
         => (IsSuccesful ? whenOk(Result) : default(TRES), this);

        public (TERR Fail, TryCatch<S, R, E> TryCatch) OnFail<TERR>(Func<S, E, TERR> whenException)
            => (!IsSuccesful ? whenException(Subject, Error) : default(TERR), this);

        public (TRES Success, TERR Fail) Then<TRES, TERR>(Func<R, TRES> whenOk, Func<S, E, TERR> whenOnException)
            => (whenOk(Result), whenOnException(Subject, Error));

        public TRES ThenMap<TRES>(Func<R, TRES> whenOk, Func<S, E, TRES> whenOnException)
            => IsSuccesful? whenOk(Result) : whenOnException(Subject, Error);
        //public (RES Success, ERR Fail) Then<RES, ERR>(Func<R, RES> whenOk, Func<S, Exception, ERR> whenOnException) => (whenOk(Result), whenOnException(Subject, Error));
        //public (RES Success, TryCatch<S, R> TryCatch) WhenSuccess<RES>(Func<R, RES> whenOk) => (whenOk(Result), this);
        //public (TryCatch<S, R> TryCatch, ERR Fail) WhenFailed<ERR>(Func<S, Exception, ERR> whenException) => (this, whenException(Subject, Error));
    }
}

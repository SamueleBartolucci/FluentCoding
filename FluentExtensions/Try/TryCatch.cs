using FluentExtensions.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FluentExtensions
{
    public class TryCatch<S, R> : WhenDo<S>
    {
        internal TryCatch() : base() { }


        public R Result { get; set; }
        public Exception Error { get; set; }
        
        
        public TryCatch<S, R> Try(Func<S, R> tryTo)
        {
            try 
            {
                tryTo(Subject); 
                IsSuccesful = true; 
            }
            catch (Exception e) 
            { 
                Error = e;
                IsSuccesful = false;
            }
            return this;
        }

        public (RES Success, ERR Fail) Then<RES, ERR>(Func<R, RES> whenOk, Func<S, Exception, ERR> whenOnException) => (whenOk(Result), whenOnException(Subject, Error));
        public (RES Success, TryCatch<S, R> TryCatch) WhenSuccess<RES>(Func<R, RES> whenOk) => (whenOk(Result), this);
        public (TryCatch<S, R> TryCatch, ERR Fail) WhenFailed<ERR>(Func<S, Exception, ERR> whenException) => (this, whenException(Subject, Error));
    }
}

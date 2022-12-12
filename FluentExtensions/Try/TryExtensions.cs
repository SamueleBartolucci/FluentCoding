using System;
using System.Linq;
using System.Security.Cryptography;

namespace FluentExtensions
{
    public static class TryExtensions
    {

        public static TryCatch<S, R> Try<S, R>(this S _, Func<S, R> tryTo) => 
            new TryCatch<S, R>() { Subject = _}
            .Try(tryTo);

        public static (R Result, E Error, S Subject) Try<S, R, E>(this S _, Func<S, R> tryTo, Func<S, Exception, E> onError) =>
            new TryCatch<S, R>() { Subject = _ }
            .Try(tryTo)
            .Map(__ => (Result: __.Result, Error: onError(__.Subject, __.Error), Subject: __.Subject));        

    }

}
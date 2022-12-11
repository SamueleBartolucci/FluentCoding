using System;
using System.Linq;
using System.Security.Cryptography;

namespace FluentExtensions
{
    public static class TryExtensions
    {

        public static TryCatch<S, R> Try<S, R>(this S _, Func<S, R> tryTo) => new TryCatch<S, R>() { Subject = _}.Try(tryTo);

        //public static (S Source, R Result, E Error) Try<S, R, E>(this S _, Func<S, R> functionToTry, Func<Exception, E> manageError)
        //{
        //    try
        //    {
        //        return (_, functionToTry(_), default(E));
        //    }
        //    catch (Exception e)
        //    {
        //        return (_, default(R), manageError(e));
        //    }
        //}

        //public static (S Source, K Result, E Error) WhenTryOk<S, R, K, E>(this (S Source, R Result, E Error) _, Func<R, K> doWhenOk)
        //    => _.Error.IsNullOrDefault() ?
        //    (_.Source, doWhenOk(_.Result), _.Error) :
        //    (_.Source, default(K), _.Error);

        //public static (S Source, R Result, X Error) WhenTryException<S, R, E, X>(this (S Source, R Result, E Error) _, Func<S, E, (S, R, X)> doWhenException)
        //    => _.Error.IsNullOrDefault() ?
        //    (_.Source, _.Result, default(X)) : doWhenException(_.Source, _.Error);

        //public static (S Source, K Result, X Error) ContinueTryWith<S, R, E, K, X>(this (S Source, R Result, E Error) _, Func<R, K> doWhenOk, Func<S, E, (S, K, X)> doWhenException) =>
        //    _.WhenTryOk(doWhenOk)
        //     .WhenTryException(doWhenException);

    }

}
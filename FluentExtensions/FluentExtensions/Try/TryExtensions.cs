using System;
using System.Linq;
using System.Security.Cryptography;

namespace FluentCoding.Try
{
    public static class TryExtensions
    {
        public static TryCatch<S, R, Exception> Try<S, R>(this S _, Func<S, R> tryTo) =>
            new TryCatch<S, R, Exception>() { Subject = _ }
            .Try(tryTo, (s, e) => e);

        public static TryCatch<S, R, E> Try<S, R, E>(this S _, Func<S, R> tryTo, Func<S, Exception, E> onError) =>
            new TryCatch<S, R, E>() { Subject = _ }
            .Try(tryTo, onError);

        public static R TryTo<S, R>(this S _, Func<S, R> tryTo, Func<S, Exception, R> onError) =>
           _.Try(tryTo, onError)
            .Map(tryCatch => tryCatch.IsSuccesful ? tryCatch.Result : tryCatch.Error);
    }

}
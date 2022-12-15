﻿using System;
using System.Linq;
using System.Security.Cryptography;


namespace FluentCoding
{
    public static class TryCatch_T
    {

        public static TryCatch<S, R, Exception> Try<S, R>(this S _, Func<S, R> tryTo) =>
            new TryCatch<S, R, Exception>() { Subject = _ }
            .Try(tryTo, (s, e) => e);

        public static TryCatch<S, R, E> Try<S, R, E>(this S _, Func<S, R> tryTo, Func<S, Exception, E> onError) =>
            new TryCatch<S, R, E>() { Subject = _ }
            .Try(tryTo, onError);
            //.Map(tryCatch => (Result: tryCatch.Result, Error: onError(tryCatch.Subject, tryCatch.Error), Subject: tryCatch.Subject));

        public static R TryWrap<S, R>(this S _, Func<S, R> tryTo, Func<S, Exception, R> onError) =>
           new TryCatch<S, R, R>() { Subject = _ }
            .Try(tryTo, onError)
            .Map(tryCatch => tryCatch.IsSuccesful? tryCatch.Result : tryCatch.Error);

    }

}
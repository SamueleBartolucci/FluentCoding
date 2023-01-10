using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace FluentCoding
{
    public static partial class TryExtensions
    {
        public static async Task<TryCatch<S, R, Exception>> TryAsync<S, R>(this Task<S> _, Func<S, R> tryTo)
            => (await _).Try(tryTo);

        public static async Task<TryCatch<S, R, E>> TryAsync<S, R, E>(this Task<S> _, Func<S, R> tryTo, Func<S, Exception, E> onError)
            => (await _).Try(tryTo, onError);


        public static async Task<TryCatch<S, S, E>> TryAsync<S, E>(this Task<S> _, Action<S> tryTo, Func<S, Exception, E> onError)
            => (await _).Try(tryTo, onError);


        public static async Task<R> TryToAsync<S, R>(this Task<S> _, Func<S, R> tryTo, Func<S, Exception, R> onError)
            => (await _).TryTo(tryTo, onError);

    }

}
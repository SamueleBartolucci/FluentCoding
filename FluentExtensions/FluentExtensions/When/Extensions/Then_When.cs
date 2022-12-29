using System;

namespace FluentCoding
{
    //public static class Then_When
    //{        
    //    public static T Then<T>(this WhenAnd<T> _, Func<T, T> whenTrue, Func<T, T> whenFalse) => _.IsSuccesful ? _.Subject.Do(whenTrue) : _.Subject.Do(whenFalse);
    //    public static T Then<T>(this WhenAnd<T> _, Func<T, T> whenTrue) => _.IsSuccesful ? _.Subject.Do(whenTrue) : _.Subject;

    //    public static T Then<T>(this WhenAnd<T> _, Action<T> whenTrue, Action<T> whenFalse) => _.IsSuccesful ? _.Subject.Do(whenTrue) : _.Subject.Do(whenFalse);

    //    public static T Then<T>(this WhenAnd<T> _, Action<T> whenTrue) => _.IsSuccesful ? _.Subject.Do(whenTrue) : _.Subject;


    //    public static K ThenMap<T,K>(this WhenAnd<T> _, Func<T, K> whenTrue, Func<T, K> whenFalse) => _.Subject.Map(_.IsSuccesful ? whenTrue : whenFalse);
    //    public static (K OnTrue, T Subject) ThenMap<T, K>(this WhenAnd<T> _, Func<T, K> whenTrue) => (_.IsSuccesful? _.Subject.Map(whenTrue) : default(K), _.Subject);
    //}
}

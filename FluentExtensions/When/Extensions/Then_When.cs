using System;

namespace FluentCoding
{
    //public class When<T> : BaseContext<T>
    //{       
    //    internal When() : base() { }

    //    public T Then(Func<T, T> whenTrue, Func<T, T> whenFalse) => IsSuccesful ? this.Subject.Do(whenTrue) : this.Subject.Do(whenFalse);
    //    public T Then(Func<T, T> whenTrue) => IsSuccesful ? Subject.Do(whenTrue) : this.Subject;

    //    public T Then(Action<T> whenTrue, Action<T> whenFalse) => IsSuccesful ? this.Subject.Do(whenTrue) : this.Subject.Do(whenFalse);
    //    public T Then(Action<T> whenTrue) => IsSuccesful ? Subject.Do(whenTrue) : this.Subject;


    //    public K ThenMap<K>(Func<T, K> whenTrue, Func<T, K> whenFalse) => this.Subject.Map(IsSuccesful? whenTrue : whenFalse);
    //    public (K OnTrue, T OnFalse) ThenMap<K>(Func<T, K> whenTrue) => (this.ThenMap(_ => _.Map(whenTrue), _ => default(K)), this.Subject);

    //    //public (T OnTrue, T OnFalse) ThenWhenTrue<K>(Func<T, K> whenTrue) => ((IsSuccesful ? this.Subject.Map(whenTrue) : default(K)), this.Subject);
    //    //public (K OnTrue, T OnFalse) ThenWhenFalse<K>(Func<T, K> whenFalse) => ((!IsSuccesful ? this.Subject.Map(whenFalse) : default(K)), this.Subject);
    //    //public (K OnTrue, T OnFalse) ThenWhenTrue<K>(Func<T, K> whenTrue) => ((IsSuccesful ? this.Subject.Map(whenTrue) : default(K)), this.Subject);
    //    //public (K OnTrue, T OnFalse) ThenWhenFalse<K>(Func<T, K> whenFalse) => ((!IsSuccesful ? this.Subject.Map(whenFalse) : default(K)), this.Subject);
    //}

    public static class Then_When
    {        
        public static T Then<T>(this WhenAnd<T> _, Func<T, T> whenTrue, Func<T, T> whenFalse) => _.IsSuccesful ? _.Subject.Do(whenTrue) : _.Subject.Do(whenFalse);
        public static T Then<T>(this WhenAnd<T> _, Func<T, T> whenTrue) => _.IsSuccesful ? _.Subject.Do(whenTrue) : _.Subject;

        public static T Then<T>(this WhenAnd<T> _, Action<T> whenTrue, Action<T> whenFalse) => _.IsSuccesful ? _.Subject.Do(whenTrue) : _.Subject.Do(whenFalse);

        public static T Then<T>(this WhenAnd<T> _, Action<T> whenTrue) => _.IsSuccesful ? _.Subject.Do(whenTrue) : _.Subject;


        public static K ThenMap<T,K>(this WhenAnd<T> _, Func<T, K> whenTrue, Func<T, K> whenFalse) => _.Subject.Map(_.IsSuccesful ? whenTrue : whenFalse);
        public static (K OnTrue, T Subject) ThenMap<T, K>(this WhenAnd<T> _, Func<T, K> whenTrue) => (_.IsSuccesful? _.Subject.Map(whenTrue) : default(K), _.Subject);
    }
}

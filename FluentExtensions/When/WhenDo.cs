using FluentExtensions.Context;
using System;

namespace FluentExtensions
{
    public class WhenDo<T> : BaseContext<T>
    {       
        internal WhenDo() : base() { }
                
        public T ThenDo(Func<T, T> whenTrue, Func<T, T> whenFalse) => IsSuccesful ? this.Subject.Do(whenTrue) : this.Subject.Do(whenFalse);
        public T ThenDo(Func<T, T> whenTrue) => IsSuccesful ? Subject.Do(whenTrue) : this.Subject;

        public T ThenDo(Action<T> whenTrue, Action<T> whenFalse) => IsSuccesful ? this.Subject.Do(whenTrue) : this.Subject.Do(whenFalse);
        public T ThenDo(Action<T> whenTrue) => IsSuccesful ? Subject.Do(whenTrue) : this.Subject;
        
                
        public K ThenMap<K>(Func<T, K> whenTrue, Func<T, K> whenFalse) => this.Subject.Map(IsSuccesful? whenTrue : whenFalse);
        public (K OnTrue, T OnFalse) ThenMap<K>(Func<T, K> whenTrue) => (this.ThenMap(_ => _.Map(whenTrue), _ => default(K)), this.Subject);

        //public (T OnTrue, T OnFalse) ThenWhenTrue<K>(Func<T, K> whenTrue) => ((IsSuccesful ? this.Subject.Map(whenTrue) : default(K)), this.Subject);
        //public (K OnTrue, T OnFalse) ThenWhenFalse<K>(Func<T, K> whenFalse) => ((!IsSuccesful ? this.Subject.Map(whenFalse) : default(K)), this.Subject);
        //public (K OnTrue, T OnFalse) ThenWhenTrue<K>(Func<T, K> whenTrue) => ((IsSuccesful ? this.Subject.Map(whenTrue) : default(K)), this.Subject);
        //public (K OnTrue, T OnFalse) ThenWhenFalse<K>(Func<T, K> whenFalse) => ((!IsSuccesful ? this.Subject.Map(whenFalse) : default(K)), this.Subject);
    }
}

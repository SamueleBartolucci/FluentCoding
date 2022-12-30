
using FluentCoding.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FluentCoding
{
    /// <summary>
    /// When->Then class. Run the 'Then' logic only if the 'When' is true
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class When<T> : BaseContext<T>
    {
        internal When() : base() { }

        public T Then(Func<T, T> whenTrue, Func<T, T> whenFalse) => IsSuccesful ? Subject.Do(whenTrue) : Subject.Do(whenFalse);
        public T Then(Func<T, T> whenTrue) => IsSuccesful ? Subject.Do(whenTrue) : Subject;

        public T Then(Action<T> whenTrue, Action<T> whenFalse) => IsSuccesful ? Subject.Do(whenTrue) : Subject.Do(whenFalse);

        public T Then(Action<T> whenTrue) => IsSuccesful ? Subject.Do(whenTrue) : Subject;


        public K ThenMap<K>(Func<T, K> whenTrue, Func<T, K> whenFalse) => Subject.Map(IsSuccesful ? whenTrue : whenFalse);
        public (K OnTrue, T Subject) ThenMap<K>(Func<T, K> whenTrue) => (IsSuccesful ? Subject.Map(whenTrue) : default(K), Subject);

    }
}

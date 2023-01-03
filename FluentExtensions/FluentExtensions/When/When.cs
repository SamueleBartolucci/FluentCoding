
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public T Then(Func<T, T> whenTrue, Func<T, T> whenFalse)  
            =>  whenFalse.Or(whenTrue, IsSuccesful)(Subject);
        public T Then(Func<T, T> whenTrue)
            => IsSuccesful ? whenTrue(Subject) : Subject;


        public T Then(Action<T> whenTrue, Action<T> whenFalse)
        {
            whenFalse.Or(whenTrue, IsSuccesful)(Subject);
            return Subject;
        }
        public T Then(Action<T> whenTrue)
        {
            if (IsSuccesful) whenTrue(Subject);
            return Subject;
        }


        public When<T> ThenAnd(Action<T> whenTrue)
        {
            if (IsSuccesful)
                whenTrue(Subject);
            
            return this;
        }

        public When<T> ThenAnd(Func<T, T> whenTrue)
        {
            if (IsSuccesful)
                whenTrue(Subject);

            return this;
        }


        public K ThenMap<K>(Func<K> whenTrue, Func<K> whenFalse) => whenFalse.Or(whenTrue, IsSuccesful)();
        public K ThenMap<K>(Func<T, K> whenTrue, Func<T, K> whenFalse) => whenFalse.Or(whenTrue, IsSuccesful)(Subject);

        public (K OnTrue, T Subject) ThenMap<K>(Func<T, K> whenTrue) => (IsSuccesful ? whenTrue(Subject) : default(K), Subject);

    }
}

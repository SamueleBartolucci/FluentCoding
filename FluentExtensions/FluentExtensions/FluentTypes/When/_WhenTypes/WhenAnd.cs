
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FluentCoding
{
    /// <summary>
    /// When->Then class. Run the 'Then' logic only if the 'When' and all the 'AndWhen' are true
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class WhenAnd<T> : When<T>
    {
        internal WhenAnd(T subject) : base(subject) { }
        internal WhenAnd(WhenAnd<T> whenOr) : base(whenOr.Subject)
        {
            IsSuccessful = whenOr.IsSuccessful;            
        }

        /// <summary>
        /// Execute andCondition(Subject) and accordingly update the IsSuccessful state
        /// </summary>
        /// <param name="andCondition"></param>
        /// <returns></returns>
        public WhenAnd<T> AndWhen(Func<T, bool> andCondition) => AndWhen(IsSuccessful && andCondition(Subject));

        /// <summary>
        /// Execute andCondition() and accordingly update the IsSuccessful state
        /// </summary>
        /// <param name="andCondition"></param>
        /// <returns></returns>
        public WhenAnd<T> AndWhen(Func<bool> andCondition) => AndWhen(IsSuccessful && andCondition());

        /// <summary>
        /// Update the IsSuccessful accordingly with the andCondition value
        /// </summary>
        /// <param name="andCondition"></param>
        /// <returns></returns>
        public WhenAnd<T> AndWhen(bool andCondition) => (this is WhenOr<T> ? new WhenAnd<T>(this) : this)
                                                            .Do(_ => _.IsSuccessful &= andCondition);

    }
}

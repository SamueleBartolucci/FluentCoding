
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
        internal WhenAnd() : base() { }
        internal WhenAnd(WhenAnd<T> whenOr) : base() 
        {
            IsSuccesful = whenOr.IsSuccesful; 
            Subject = whenOr.Subject; 
        }

        /// <summary>
        /// Execute andCondition(Subject) and accordingly update the IsSuccesful state
        /// </summary>
        /// <param name="andCondition"></param>
        /// <returns></returns>
        public WhenAnd<T> AndWhen(Func<T, bool> andCondition) => AndWhen(andCondition(Subject));

        /// <summary>
        /// Execute andCondition() and accordingly update the IsSuccesful state
        /// </summary>
        /// <param name="andCondition"></param>
        /// <returns></returns>
        public WhenAnd<T> AndWhen(Func<bool> andCondition) => AndWhen(andCondition());

        /// <summary>
        /// Update the IsSuccesful accordingly with the andCondition value
        /// </summary>
        /// <param name="andCondition"></param>
        /// <returns></returns>
        public WhenAnd<T> AndWhen(bool andCondition) =>  ((this is WhenOr<T>)? new WhenAnd<T>(this) : this)
                                                            .Do(_ => _.IsSuccesful &= andCondition);

    }
}

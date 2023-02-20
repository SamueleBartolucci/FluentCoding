

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FluentCoding
{
    /// <summary>
    /// When->Then class. Run the 'Then' logic only if at least one between 'When' and 'OrWhen' is true
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class WhenOr<T> : WhenAnd<T>
    {
        internal WhenOr() : base() { }

        /// <summary>
        /// Execute orCondition(Subject) and accordingly update the IsSuccessful state
        /// </summary>
        /// <param name="orCondition"></param>
        /// <returns></returns>
        public WhenAnd<T> OrWhen(Func<T, bool> orCondition) => OrWhen(orCondition(Subject));

        /// <summary>
        /// Execute orCondition() and accordingly update the IsSuccessful state
        /// </summary>
        /// <param name="orCondition"></param>
        /// <returns></returns>
        public WhenAnd<T> OrWhen(Func<bool> orCondition) => OrWhen(orCondition());

        /// <summary>
        /// Update the IsSuccessful state accordingly to the orCondition value
        /// </summary>
        /// <param name="orCondition"></param>
        /// <returns></returns>
        public WhenAnd<T> OrWhen(bool orCondition) => this.Do(_ => _.IsSuccessful |= orCondition);
    }
}


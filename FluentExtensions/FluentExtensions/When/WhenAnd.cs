
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

        public WhenAnd<T> AndWhen(Func<T, bool> andCondition) => AndWhen(andCondition(Subject));
        public WhenAnd<T> AndWhen(Func<bool> andCondition) => AndWhen(andCondition());
        public WhenAnd<T> AndWhen(bool andCondition) => this.Or(new WhenAnd<T>(this), this is WhenOr<T>)
                                                            .Do(_ => _.IsSuccesful &= andCondition);

    }
}

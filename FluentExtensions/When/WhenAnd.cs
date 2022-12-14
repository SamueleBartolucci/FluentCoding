
using FluentCoding.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FluentCoding
{
    public class WhenAnd<T> : BaseContext<T>
    {
        internal WhenAnd() : base() { }
        internal WhenAnd(WhenAnd<T> whenOr) : base() 
        {
            IsSuccesful = whenOr.IsSuccesful; 
            Subject = whenOr.Subject; 
        }

        public WhenAnd<T> AndWhen(Func<T, bool> andCondition) => this.AndWhen(andCondition(Subject));//this.Do(_ => _.IsSuccesful &= and(_.Subject));
        public WhenAnd<T> AndWhen(Func<bool> andCondition) => this.AndWhen(andCondition());//this.Do(_ => _.IsSuccesful &= and());
        public WhenAnd<T> AndWhen(bool andCondition) => this.Or(new WhenAnd<T>(this), this is WhenOr<T>).Do(_ => _.IsSuccesful &= andCondition);

    }
}

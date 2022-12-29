
using FluentCoding.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FluentCoding
{
    public class WhenOr<T> : WhenAnd<T>
    {
        internal WhenOr() : base() { }

        public WhenAnd<T> OrWhen(Func<T, bool> orCondition) => this.OrWhen(orCondition(Subject));//this.Do(_ => _.IsSuccesful |= orCondition(_.Subject));
        public WhenAnd<T> OrWhen(Func<bool> orCondition) => this.OrWhen(orCondition());// this.Do(_ => _.IsSuccesful |= orCondition());
        public WhenAnd<T> OrWhen(bool orCondition) => this.Do(_ => _.IsSuccesful |= orCondition);
    }
}


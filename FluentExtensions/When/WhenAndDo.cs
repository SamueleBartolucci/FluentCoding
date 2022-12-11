using FluentExtensions.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FluentExtensions
{
    public class WhenAndDo<T> : WhenDo<T>
    {
        internal WhenAndDo() : base() { }
        public WhenAndDo<T> AndWhen(Func<T, bool> and) => this.Do(_ => _.IsSuccesful &= and(_.Subject));

    }
}

using FluentExtensions.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FluentExtensions
{
    public class WhenOrAndDo<T> : WhenAndDo<T>
    {
        internal WhenOrAndDo() : base() { }
        public WhenDo<T> OrWhen(Func<T, bool> and) => this.Do(_ => _.IsSuccesful |= and(_.Subject));        
    }
}

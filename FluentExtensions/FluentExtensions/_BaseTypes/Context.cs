using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding
{
    public class Context<T>
    {
        internal Context() { }

        /// <summary>
        /// Subject from which the fluent operation started
        /// </summary>
        public T Subject { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding
{
    public class FluentContext<T>
    {
        internal FluentContext() { }

        /// <summary>
        /// Status of the current fluent operation
        /// </summary>
        public bool IsSuccesful { get; set; }

        /// <summary>
        /// Subject from which the fluent operation started
        /// </summary>
        public T Subject { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding
{
    public class FluentContext<T> : Context<T>
    {
        internal FluentContext() { }

        /// <summary>
        /// Status of the current fluent operation
        /// </summary>
        public bool IsSuccessful { get; set; }

    }
}

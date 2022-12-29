using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding.Context
{
    public class BaseContext<T>
    {
        internal BaseContext() { }

        public bool IsSuccesful { get; set; }

        public T Subject { get; set; }
    }
}

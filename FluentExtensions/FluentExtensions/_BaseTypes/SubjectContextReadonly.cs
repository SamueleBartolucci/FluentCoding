using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding
{
    public class SubjectContextReadonly<T> : SubjectContext<T>
    {
        internal SubjectContextReadonly(T subject) : base(subject) { }
        
        /// <summary>
        /// Subject from which the fluent operation started
        /// </summary>
        public new T Subject => base.Subject;
    }
}

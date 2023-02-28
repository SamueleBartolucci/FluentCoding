using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding
{
    public class SubjectContext<T>
    {
        internal SubjectContext(T subject) { _subject = subject; }

        private T _subject;
        /// <summary>
        /// Subject from which the fluent operation started
        /// </summary>
        public T Subject 
        {
            get { return _subject; } 
            set { _subject = value; }
        }
    }
}

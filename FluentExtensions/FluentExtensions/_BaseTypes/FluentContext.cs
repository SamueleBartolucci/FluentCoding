using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding
{
    public class FluentContext<T> : SubjectContextReadonly<T>
    {

        /// <summary>
        /// Truthy/Falsy operator
        /// </summary>
        /// <param name="context"></param>
        public static implicit operator bool(FluentContext<T> context) => context.IsSuccessful;

        /// <summary>
        /// Truthy operator
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static bool operator true(FluentContext<T> context) => context.IsSuccessful;

        /// <summary>
        /// Falsy operator 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static bool operator false(FluentContext<T> context) => !context.IsSuccessful;

        /// <summary>
        /// Negation operator 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static bool operator !(FluentContext<T> context) => !context.IsSuccessful;

        internal FluentContext(T subject) : base(subject) { }

        /// <summary>
        /// Status of the current fluent operation
        /// </summary>
        public bool IsSuccessful { get; set; }

    }
}

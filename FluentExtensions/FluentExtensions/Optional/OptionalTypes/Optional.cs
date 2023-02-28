using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding
{
    /// <summary>
    /// Wrapper to safe manage nullable/default values
    /// </summary>
    /// <typeparam name="O">optional type</typeparam>
    public class Optional<O> : FluentContext<O>
    {
        private Optional(O optionalValue, bool isSomething) : base(optionalValue) { IsSuccessful = isSomething; }

        /// <summary>
        /// Return Some of the input value
        /// If the value is null the return is None
        /// </summary>
        /// <typeparam name="O"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Optional<O> Some(O value) 
            => value == null ? None() : new Optional<O>(value, true);

        /// <summary>
        /// Return None
        /// </summary>
        /// <returns></returns>
        public static Optional<O> None() 
            => new Optional<O>(default, false);

        /// <summary>
        /// Check if Optional value is some
        /// </summary>
        /// <returns></returns>
        public bool IsSome() => this.IsSuccessful;

        /// <summary>
        /// Check if Optional value is None
        /// </summary>
        /// <returns></returns>
        public bool IsNone() => !this.IsSuccessful;

    }
}

using System.Diagnostics.Contracts;
using System;
using FluentCoding.Extensions.Is.Is.T;

namespace FluentCoding
{
    /// <summary>
    /// Wrapper to safe manage nullable/default values
    /// </summary>
    /// <typeparam name="O">optional type</typeparam>
    public partial class Optional<O> : FluentContext<O>
    {
        private Optional(O optionalValue, bool isSomething) : base(optionalValue) { IsSuccessful = isSomething; }

        public static explicit operator O(Optional<O> input) => input.IsSome() ? input.Subject : default(O);
        public static implicit operator Optional<O>(O input) => input.IsNullOrEquivalent()? None() : Some(input);
        public static implicit operator bool(Optional<O> input) => input.IsSome();
        public static bool operator true(Optional<O> input) => input.IsSome();
        public static bool operator false(Optional<O> input) => input.IsNone();
        public static bool operator !(Optional<O> input) => input.IsNone();

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


        /// <summary>
        /// Apply an action on the Subject when IsSome
        /// Same as Subject.DoOptn(action)
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public Optional<O> WhenSome(Action<O> action)
            => this.DoOptn(action);

        /// <summary>
        /// Apply a generic action when the subject IsNone        
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public Optional<O> WhenNone(Action action)
            => this.When(IsNone()).Then(_ => action());
                 
    }
}



using System;

namespace FluentCoding
{
    /// <summary>
    /// When->Then class. Run the 'Then' logic only if at least one between 'When' and 'OrWhen' is true
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class WhenOr<T> : WhenAnd<T>
    {
        internal WhenOr(T subject) : base(subject) { }

        /// <summary>
        /// Execute orCondition(Subject) and accordingly update the IsSuccessful state
        /// </summary>
        /// <param name="orCondition"></param>
        /// <returns></returns>
        public WhenAnd<T> OrWhen(Func<T, bool> orCondition) => OrWhen(IsSuccessful || orCondition(Subject));

        /// <summary>
        /// Execute orCondition() and accordingly update the IsSuccessful state
        /// </summary>
        /// <param name="orCondition"></param>
        /// <returns></returns>
        public WhenAnd<T> OrWhen(Func<bool> orCondition) => OrWhen(IsSuccessful || orCondition());

        /// <summary>
        /// Update the IsSuccessful state accordingly to the orCondition value
        /// </summary>
        /// <param name="orCondition"></param>
        /// <returns></returns>
        public WhenAnd<T> OrWhen(bool orCondition) => this.Do(when => when.IsSuccessful |= orCondition);
    }
}


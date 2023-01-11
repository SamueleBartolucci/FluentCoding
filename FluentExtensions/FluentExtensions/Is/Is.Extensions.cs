using System;
using System.Runtime.CompilerServices;

namespace FluentCoding
{
    public static class IsExtensions
    {
        /// <summary>
        /// Check if satisfyCondition is true or false, return a tuple with (IsSatisfied, Subject)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject"></param>
        /// <param name="satisfyCondition"></param>
        /// <returns></returns>
        public static (bool IsSatisfied, T Subject) Is<T>(this T subject, bool satisfyCondition)
            => (satisfyCondition, subject);

        /// <summary>
        /// Check if satisfyCondition() is true or false, return a tuple with (IsSatisfied, Subject)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject"></param>
        /// <param name="satisfyCondition"></param>
        /// <returns></returns>
        public static (bool IsSatisfied, T Subject) Is<T>(this T subject, Func<bool> satisfyCondition)
            => subject.Is(satisfyCondition());

        /// <summary>
        /// Check if satisfyCondition(Subject) is true or false, return a tuple with (IsSatisfied, Subject)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject"></param>
        /// <param name="satisfyCondition"></param>
        /// <returns></returns>
        public static (bool IsSatisfied, T Subject) Is<T>(this T subject, Func<T, bool> satisfyCondition)
            => subject.Is(satisfyCondition(subject));
    }
}
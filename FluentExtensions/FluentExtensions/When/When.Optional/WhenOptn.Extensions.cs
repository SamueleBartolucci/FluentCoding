using System;
using System.Xml.Linq;
using FluentCoding;

namespace FluentCoding
{
    public static partial class WhenExtensions
    {
        /// <summary>
        /// Create a When context and set IsSuccessful to true if Subject.IsSome() and whenCondition(subject) are true
        /// Then set IsSuccessful accordingly
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whenSubject"></param>
        /// <param name="whenCondition"></param>
        /// <returns></returns>
        public static WhenOr<Optional<T>> WhenOptn<T>(this Optional<T> whenSubject, Func<T, bool> whenCondition) 
            => new WhenOr<Optional<T>>(whenSubject) { IsSuccessful = whenSubject.IsSome() && whenCondition(whenSubject.Subject) };

        /// <summary>
        /// Create a When context and set IsSuccessful to true if Subject.IsSome() and whenCondition() are true
        /// Then set IsSuccessful accordingly
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whenSubject"></param>
        /// <param name="whenCondition"></param>
        /// <returns></returns>
        public static WhenOr<Optional<T>> WhenOptn<T>(this Optional<T> whenSubject, Func<bool> whenCondition)
            => new WhenOr<Optional<T>>(whenSubject) { IsSuccessful = whenSubject.IsSome() && whenCondition() };

        /// <summary>
        /// Create a When context and set IsSuccessful to true if Subject.IsSome() and whenCondition are true
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whenSubject"></param>
        /// <param name="whenCondition"></param>
        /// <returns></returns>
        public static WhenOr<Optional<T>> WhenOptn<T>(this Optional<T> whenSubject, bool whenCondition)
            => new WhenOr<Optional<T>>(whenSubject) { IsSuccessful = whenSubject.IsSome() && whenCondition };
    }
}

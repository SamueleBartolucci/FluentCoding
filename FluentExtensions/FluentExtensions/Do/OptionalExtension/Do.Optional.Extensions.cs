using System;
using System.Diagnostics.CodeAnalysis;

namespace FluentCoding
{
    public static partial class DoOptionalExtensions
    {
        /// <summary>
        /// Apply a set of actions to the Subject (when this is not null) wrapped inside and Context&lt;T&gt;.Subject field.
        /// Allows to quickly manipulate values type as references types
        /// Then return the subject unwrapped, only the return value is changed not the original value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="optionalSubject"></param>
        /// <param name="doOnSubject"></param>
        /// <returns></returns>
        public static Optional<T> DoWrap<T>(this Optional<T> optionalSubject, params Action<SubjectContext<T>>[] doOnSubject)
        {

            if (optionalSubject?.IsSome() ?? false)
            {
                var tmp = new SubjectContext<T>(optionalSubject.Subject) { };
                tmp.Do(doOnSubject);
                return tmp.Subject.ToOptional();
            }

            return optionalSubject;
        }

        /// <summary>
        /// Apply a set of actions to the subject (when this is not null)
        /// Then return the subject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="optionalSubject"></param>
        /// <param name="doOnSubject"></param>
        /// <returns></returns>
        public static Optional<T> Do<T>(this Optional<T> optionalSubject, params Action<T>[] doOnSubject)
        {
            if (optionalSubject?.IsSome() ?? false)
            {
                foreach (var doOnSbj in doOnSubject)
                    doOnSbj(optionalSubject.Subject);
            }

            return optionalSubject;
        }

        /// <summary>
        /// Apply an set of function to the subject  (when this is not null)
        /// Then return the subject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="optionalSubject"></param>
        /// <param name="doOnSubject"></param>
        /// <returns></returns>
        public static Optional<T> Do<T>(this Optional<T> optionalSubject, params Func<T, T>[] doOnSubject)
        {
            if (optionalSubject?.IsSome() ?? false)
            {                
                foreach (var doOnSbj in doOnSubject)
                    doOnSbj(optionalSubject.Subject);
            }

            return optionalSubject;
        }
    }
}
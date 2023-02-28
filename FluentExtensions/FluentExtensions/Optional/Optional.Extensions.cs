using System;

namespace FluentCoding
{
    public static partial class OptionalExtensions
    {
        /// <summary>
        /// Convert the subject into an Optional of subject.
        /// When subject is null it returns None Optional
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject"></param>
        /// <returns></returns>
        public static Optional<T> ToOptional<T>(this T subject) 
            => subject != null? 
                Optional<T>.Some(subject) : 
                Optional<T>.None();
    }
}
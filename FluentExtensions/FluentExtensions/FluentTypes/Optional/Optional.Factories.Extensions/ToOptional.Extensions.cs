using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

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

        /// <summary>
        /// Convert the enumerable items into Optional
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalEnumerable"></param>
        /// <returns></returns>
        public static IEnumerable<Optional<T>> ToOptionalForEach<T>(this IEnumerable<T> originalEnumerable)
             => originalEnumerable?.MapForEach(org => org.ToOptional());

    }
}
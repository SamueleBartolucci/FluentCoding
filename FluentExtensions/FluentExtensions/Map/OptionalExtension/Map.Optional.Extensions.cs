using System;

namespace FluentCoding
{
    public static partial class MapExtensions
    {
        /// <summary>
        /// Apply the mapping function on the subject and return the result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="subject"></param>
        /// <param name="mapSubject"></param>
        /// <returns></returns>
        public static Optional<K> Map<T, K>(this Optional<T> subject, Func<T, K> mapSubject) 
            => subject == null || subject ?
                        Optional<K>.None() : 
                        subject.Subject.Map(mapSubject).ToOptional();

    }
}
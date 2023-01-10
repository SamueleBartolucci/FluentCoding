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
        public static K Map<T, K>(this T subject, Func<T, K> mapSubject) => subject == null ? default(K) : mapSubject(subject);

        /// <summary>
        /// Apply the mapping function without using the subject data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="subject"></param>
        /// <param name="mapWithoutSubjectContext"></param>
        /// <returns></returns>
        public static K Map<T, K>(this T subject, Func<K> mapWithoutSubjectContext) => mapWithoutSubjectContext();
    }
}
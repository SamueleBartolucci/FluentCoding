using System;

namespace FluentCoding
{
    //public partial class Optional<O> : FluentContext<O>
    public static partial class MapExtensions
    {
        /// <summary>
        /// Apply the mapping function on the subject when IsSome and return the result
        /// Otherwise return None
        /// </summary>
        /// <typeparam name="O"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="subject"></param>
        /// <param name="mapSubject"></param>
        /// <returns></returns>
        public Optional<K> MapOptional<K>(Func<O, K> mapSubject) 
            => IsNone() ?
                Optional<K>.None() : 
                Subject.Map(mapSubject).ToOptional();

    }
}
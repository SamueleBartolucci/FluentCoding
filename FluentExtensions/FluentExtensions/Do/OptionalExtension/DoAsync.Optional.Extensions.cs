﻿using System;
using System.Threading.Tasks;

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
        /// <param name="_"></param>
        /// <param name="doOnSubject"></param>
        /// <returns></returns>
        public static async Task<Optional<T>> DoWrapAsync<T>(this Task<Optional<T>> _, params Action<SubjectContext<T>>[] doOnSubject)
            => (await _).DoWrap(doOnSubject);

        /// <summary>
        /// Apply an set of actions to the subject when this is not null then return the subject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_"></param>
        /// <param name="doOnSubject"></param>
        /// <returns></returns>
        public static async Task<Optional<T>> DoAsync<T>(this Task<Optional<T>> _, params Action<T>[] doOnSubject)
            => (await _).Do(doOnSubject);

        /// <summary>
        /// Apply a set of function on the subject when this is not null then return the Func result or the subject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_"></param>
        /// <param name="doOnSubject"></param>
        /// <returns></returns>
        public static async Task<Optional<T>> DoAsync<T>(this Task<Optional<T>> _, params Func<T, T>[] doOnSubject)
            => (await _).Do(doOnSubject);
    }
}
﻿using System;
using System.Threading.Tasks;
using System.Xml.Linq;
using FluentCoding;

namespace FluentCoding
{
    public static partial class WhenExtensions
    {
        /// <summary>
        /// Create a When context and set IsSuccessful status with the result of whenCondition(subject)
        /// Then set IsSuccessfull accordingly
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whenSubject"></param>
        /// <param name="whenCondition"></param>
        /// <returns></returns>
        public static async Task<WhenOr<T>> WhenAsync<T>(this Task<T> whenSubject, Func<T, bool> whenCondition)
            => (await whenSubject).When(whenCondition);

        /// <summary>
        /// Create a When context and set IsSuccessful status with the result of whenCondition()
        /// Then set IsSuccessfull accordingly
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whenSubject"></param>
        /// <param name="whenCondition"></param>
        /// <returns></returns>
        public static async Task<WhenOr<T>> WhenAsync<T>(this Task<T> whenSubject, Func<bool> whenCondition)
            => (await whenSubject).When(whenCondition);

        /// <summary>
        /// Create a When context and set IsSuccessful status with the value of whenCondition
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whenSubject"></param>
        /// <param name="whenCondition"></param>
        /// <returns></returns>
        public static async Task<WhenOr<T>> WhenAsync<T>(this Task<T> whenSubject, bool whenCondition)
            => (await whenSubject).When(whenCondition);
    }
}

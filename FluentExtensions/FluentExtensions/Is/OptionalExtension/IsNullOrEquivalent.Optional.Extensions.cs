﻿using System;

namespace FluentCoding
{
    public static class IsNullOrEquivalentOptionalExtensions
    {
        /// <summary>
        /// Check if an object is null or an equivalent state
        /// By default String.Empty is equivalent to null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="setupCustomOptions"></param>
        /// <returns></returns>
        public static bool IsNullOrEquivalent<T>(this Optional<T> @this, Action<IsNullOptions> setupCustomOptions = null)
            => @this.IsNone() || @this.Subject.IsNullOrEquivalent();

    }
}
using System;
using System.Xml.Linq;
using FluentCoding;

namespace FluentCoding
{
    public static partial class WhenExtensions
    {
        /// <summary>
        /// Create a When context and set IsSuccesful status with the result of whenCondition(subject)
        /// Then set IsSuccesfull accordingly
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whenSubject"></param>
        /// <param name="whenCondition"></param>
        /// <returns></returns>
        public static WhenOr<T> When<T>(this T whenSubject, Func<T, bool> whenCondition) 
            => new WhenOr<T>() { IsSuccesful = whenCondition(whenSubject), Subject = whenSubject };

        /// <summary>
        /// Create a When context and set IsSuccesful status with the result of whenCondition()
        /// Then set IsSuccesfull accordingly
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whenSubject"></param>
        /// <param name="whenCondition"></param>
        /// <returns></returns>
        public static WhenOr<T> When<T>(this T whenSubject, Func<bool> whenCondition)
            => new WhenOr<T>() { IsSuccesful = whenCondition(), Subject = whenSubject };

        /// <summary>
        /// Create a When context and set IsSuccesful status with the value of whenCondition
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whenSubject"></param>
        /// <param name="whenCondition"></param>
        /// <returns></returns>
        public static WhenOr<T> When<T>(this T whenSubject, bool whenCondition)
            => new WhenOr<T>() { IsSuccesful = whenCondition, Subject = whenSubject };
    }
}

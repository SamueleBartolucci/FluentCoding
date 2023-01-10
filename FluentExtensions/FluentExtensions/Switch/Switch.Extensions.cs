using System;
using System.Linq;

namespace FluentCoding
{
    public static partial class SwitchExtensions
    {
        /// <summary>
        /// Search the first whenPredicate(subject) == true and apply its  actionWhenTrue(subject)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject"></param>
        /// <param name="defaultAction"></param>
        /// <param name="cases"></param>
        /// <returns></returns>
        public static T Switch<T>(this T subject, Func<T, T> defaultAction, params (Func<T, bool> whenPredicate, Func<T, T> actionWhenTrue)[] cases)
            => cases.FirstOrDefault(@case => @case.whenPredicate(subject))
                      .Map(o => o.actionWhenTrue)
                      .Or(defaultAction)(subject);

        /// <summary>
        /// Search the first whenPredicate() == true and apply its actionWhenTrue(subject)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject"></param>
        /// <param name="defaultAction"></param>
        /// <param name="cases"></param>
        /// <returns></returns>
        public static T Switch<T>(this T subject, Func<T, T> defaultAction, params (Func<bool> whenPredicate, Func<T, T> actionWhenTrue)[] cases)
            => cases.FirstOrDefault(option => option.whenPredicate())
                      .Map(o => o.actionWhenTrue)
                      .Or(defaultAction)(subject);


        /// <summary>
        /// Search the first whenPredicate == true and apply its actionWhenTrue(subject)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subject"></param>
        /// <param name="defaultAction"></param>
        /// <param name="cases"></param>
        /// <returns></returns>
        public static T Switch<T>(this T subject, Func<T, T> defaultAction, params (bool whenPredicate, Func<T, T> actionWhenTrue)[] cases)
          => cases.FirstOrDefault(option => option.whenPredicate)
                    .Map(o => o.actionWhenTrue)
                    .Or(defaultAction)(subject);


    }
}
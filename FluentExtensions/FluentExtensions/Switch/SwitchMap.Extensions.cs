using System;
using System.Linq;

namespace FluentCoding
{
    public static partial class SwitchMapExtensions
    {
        /// <summary>
        /// Search the first whenPredicate(subject) == true and apply its  mapActionWhenTrue(subject)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="subject"></param>
        /// <param name="defaultAction"></param>
        /// <param name="cases"></param>
        /// <returns></returns>
        public static K SwitchMap<T, K>(this T subject, Func<T, K> defaultAction, params (Func<T, bool> whenPredicate, Func<T, K> mapActionWhenTrue)[] cases)
             => cases.FirstOrDefault(option => option.whenPredicate(subject))
                       .Map(o => o.mapActionWhenTrue)
                       .Or(defaultAction)(subject);
        /// <summary>
        /// Search the first whenPredicate() == true and apply its mapActionWhenTrue(subject)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="subject"></param>
        /// <param name="defaultAction"></param>
        /// <param name="cases"></param>
        /// <returns></returns>
        public static K SwitchMap<T, K>(this T subject, Func<T, K> defaultAction, params (Func<bool> whenPredicate, Func<T, K> mapActionWhenTrue)[] cases)
            => cases.FirstOrDefault(option => option.whenPredicate())
                      .Map(o => o.mapActionWhenTrue)
                      .Or(defaultAction)(subject);

        /// <summary>
        /// Search the first whenPredicate == true and apply its mapActionWhenTrue(subject)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="subject"></param>
        /// <param name="defaultAction"></param>
        /// <param name="cases"></param>
        /// <returns></returns>
        public static K SwitchMap<T, K>(this T subject, Func<T, K> defaultAction, params (bool whenPredicate, Func<T, K> mapActionWhenTrue)[] cases)
          => cases.FirstOrDefault(option => option.whenPredicate)
                    .Map(o => o.mapActionWhenTrue)
                    .Or(defaultAction)(subject);
    }
}
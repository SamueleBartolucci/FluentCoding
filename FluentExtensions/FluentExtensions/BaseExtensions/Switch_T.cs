using System;
using System.Linq;

namespace FluentCoding
{
    public static class Switch_T
    {
        public static T Switch<T>(this T _, Func<T, T> defaultAction, params (Func<T, bool> predicate, Func<T, T> action)[] cases)
            => cases.FirstOrDefault(option => option.predicate(_))
                      .Map(o => o.action)
                      .Or(defaultAction)(_);

        public static T Switch<T>(this T _, Func<T, T> defaultAction, params (Func<bool> predicate, Func<T, T> action)[] cases)
            => cases.FirstOrDefault(option => option.predicate())
                      .Map(o => o.action)
                      .Or(defaultAction)(_);

        public static T Switch<T>(this T _, Func<T, T> defaultAction, params (bool predicate, Func<T, T> action)[] cases)
          => cases.FirstOrDefault(option => option.predicate)
                    .Map(o => o.action)
                    .Or(defaultAction)(_);


        public static K SwitchMap<T, K>(this T _, Func<T, K> defaultAction, params (Func<T, bool> predicate, Func<T, K> action)[] cases)
             => cases.FirstOrDefault(option => option.predicate(_))
                       .Map(o => o.action)
                       .Or(defaultAction)(_);

        public static K SwitchMap<T, K>(this T _, Func<T, K> defaultAction, params (Func<bool> predicate, Func<T, K> action)[] cases)
            => cases.FirstOrDefault(option => option.predicate())
                      .Map(o => o.action)
                      .Or(defaultAction)(_);

        public static K SwitchMap<T, K>(this T _, Func<T, K> defaultAction, params (bool predicate, Func<T, K> action)[] cases)
          => cases.FirstOrDefault(option => option.predicate)
                    .Map(o => o.action)
                    .Or(defaultAction)(_);
    }
}
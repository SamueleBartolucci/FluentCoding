using System;

namespace FluentExtensions
{
    public static class WhenExtension
    {
        public static WhenDo<T> When<T>(this T whenSubject, Func<T, bool> whenCondition) => new WhenDo<T>() { Subject = whenSubject }.Do(_ => _.IsSuccesful = whenCondition(_.Subject));
        public static WhenDo<T> When<T>(this T whenSubject, bool whenCondition) => new WhenDo<T>() { Subject = whenSubject }.Do(_ => _.IsSuccesful = whenCondition);

        //public static WhenDo<T> WhenNot<T>(this T whenSubject, Func<T, bool> whenCondition) => new WhenDo<T>() { Subject = whenSubject }.Do(_ => _.IsSuccesful = !whenCondition(_.Subject));
        //public static WhenDo<T> WhenNot<T>(this T whenSubject, bool whenCondition) => new WhenDo<T>() { Subject = whenSubject}.Do(_ => _.IsSuccesful = !whenCondition);
    }
}

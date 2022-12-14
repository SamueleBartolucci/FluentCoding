using System;


namespace FluentCoding
{
    public static class When_T
    {
        
        public static WhenOr<T> When<T>(this T whenSubject, Func<T, bool> whenCondition) => new WhenOr<T>() { Subject = whenSubject }.Do(_ => _.IsSuccesful = whenCondition(_.Subject));
        public static WhenOr<T> When<T>(this T whenSubject, Func<bool> whenCondition) => new WhenOr<T>() { Subject = whenSubject }.Do(_ => _.IsSuccesful = whenCondition());
        public static WhenOr<T> When<T>(this T whenSubject, bool whenCondition) => new WhenOr<T>() { Subject = whenSubject }.Do(_ => _.IsSuccesful = whenCondition);

        //public static When<T> WhenNot<T>(this T whenSubject, Func<T, bool> whenCondition) => new When<T>() { Subject = whenSubject }.Do(_ => _.IsSuccesful = !whenCondition(_.Subject));
        //public static When<T> WhenNot<T>(this T whenSubject, bool whenCondition) => new When<T>() { Subject = whenSubject}.Do(_ => _.IsSuccesful = !whenCondition);
    }
}

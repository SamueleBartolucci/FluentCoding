using System;

namespace FluentCoding
{
    public static partial class OrExtensions
    {
        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null, not None  and chooseRight bool is false
        /// Empty string is considered NOT null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValue"></param>
        /// <param name="chooseRight"></param>
        /// <returns></returns>
        public static T OrOptn<T>(this Optional<T> leftValue, T orRightValue, bool chooseRight = false)
            => (leftValue == null || leftValue.IsNone() || chooseRight) ? orRightValue : leftValue.Subject;

        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null, not None and chooseRight bool is false
        /// Empty string is considered NOT null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValue"></param>
        /// <param name="chooseRight"></param>
        /// <returns></returns>
        public static Optional<T> OrOptn<T>(this Optional<T> leftValue, Optional<T> orRightValue, bool chooseRight = false)
           => (leftValue == null || leftValue.IsNone() || chooseRight) ? orRightValue : leftValue;

        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null, not None  and chooseRightWhen() is false
        /// Empty string is considered NOT null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValue"></param>
        /// <param name="chooseRightWhen"></param>
        /// <returns></returns>
        public static T OrOptn<T>(this Optional<T> leftValue, T orRightValue, Func<bool> chooseRightWhen)
            => leftValue.OrOptn(orRightValue, chooseRightWhen());


        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null, not None  and chooseRightWhen() is false
        /// Empty string is considered NOT null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValue"></param>
        /// <param name="chooseRightWhen"></param>
        /// <returns></returns>
        public static Optional<T> OrOptn<T>(this Optional<T> leftValue, Optional<T> orRightValue, Func<bool> chooseRightWhen)
            => leftValue.OrOptn(orRightValue, chooseRightWhen());

        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null, not None  and chooseRightWhen(leftValue) is false
        /// Empty string is considered NOT null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValue"></param>
        /// <param name="chooseRightWhen"></param>
        /// <returns></returns>
        public static T OrOptn<T>(this Optional<T> leftValue, T orRightValue, Func<T, bool> chooseRightWhen)
            => leftValue.OrOptn(orRightValue, leftValue.IsNone() || chooseRightWhen(leftValue.Subject));

        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null, not None  and chooseRightWhen(leftValue) is false
        /// Empty string is considered NOT null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValue"></param>
        /// <param name="chooseRightWhen"></param>
        /// <returns></returns>
        public static Optional<T> OrOptn<T>(this Optional<T> leftValue, Optional<T> orRightValue, Func<T, bool> chooseRightWhen)
            => leftValue.OrOptn(orRightValue, leftValue.IsNone() || chooseRightWhen(leftValue.Subject));

        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null, not None  and chooseRightWhen(leftValue, orRightValue) is false
        /// Empty string is considered NOT null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValue"></param>
        /// <param name="chooseRightWhen"></param>
        /// <returns></returns>
        public static T OrOptn<T>(this Optional<T> leftValue, T orRightValue, Func<T, T, bool> chooseRightWhen)
            => leftValue.OrOptn(orRightValue, leftValue.IsNone() || chooseRightWhen(leftValue.Subject, orRightValue));


        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null, not None  and chooseRightWhen(leftValue, orRightValue) is false
        /// Empty string is considered NOT null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValue"></param>
        /// <param name="chooseRightWhen"></param>
        /// <returns></returns>
        public static Optional<T> OrOptn<T>(this Optional<T> leftValue, Optional<T> orRightValue, Func<T, T, bool> chooseRightWhen)
            => leftValue.OrOptn(orRightValue, leftValue.IsNone() || orRightValue.When(v => v.IsSome())
                                                                                .Then(v => chooseRightWhen(leftValue.Subject, orRightValue.Subject),
                                                                                      _ => false));


    }
}
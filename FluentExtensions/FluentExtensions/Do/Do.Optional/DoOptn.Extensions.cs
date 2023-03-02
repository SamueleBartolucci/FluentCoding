using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace FluentCoding
{
    //public partial class Optional<O> : FluentContext<O>
    public static partial class DoOptionalExtensions
    {

        /// <summary>
        /// Apply a set of actions to the Optional subject when IsSome
        /// Then return the subject        
        /// </summary>
        /// <typeparam name="O"></typeparam>
        /// <param name="optionalValue"></param>
        /// <param name="doOnSubject"></param>
        /// <returns></returns>
        public static Optional<O> DoOptn<O>(this Optional<O> optionalValue, params Action<O>[] doOnSubject)
        {
            if (optionalValue?.IsSome() ?? false)
            {
                foreach (var doOnSbj in doOnSubject)
                    doOnSbj(optionalValue.Subject);
            }

            return optionalValue;
        }

        //public Optional<O> DoOptn(params Action<O>[] doOnSubject)
        //{
        //    if (IsSome())
        //    {
        //        foreach (var doOnSbj in doOnSubject)
        //            doOnSbj(Subject);
        //    }

        //    return this;
        //}

        /// <summary>
        /// Apply a set of actions to the Optional subject when IsSome
        /// Then return the subject
        /// </summary>
        /// <typeparam name="O"></typeparam>
        /// <param name="optionalValue"></param>
        /// <param name="doOnSubject"></param>
        /// <returns></returns>
        public static Optional<O> DoOptn<O>(this Optional<O> optionalValue, params Func<O, O>[] doOnSubject)
        {
            if (optionalValue?.IsSome() ?? false)
            {
                foreach (var doOnSbj in doOnSubject)
                    doOnSbj(optionalValue.Subject);
            }

            return optionalValue;
        }

        //public Optional<O> DoOptn(params Func<O, O>[] doOnSubject)
        //{
        //    if (IsSome())
        //    {
        //        foreach (var doOnSbj in doOnSubject)
        //            doOnSbj(Subject);
        //    }

        //    return this;
        //}
    }
}
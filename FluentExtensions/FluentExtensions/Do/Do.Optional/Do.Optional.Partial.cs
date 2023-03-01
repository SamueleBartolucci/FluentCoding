using System;
using System.Diagnostics.CodeAnalysis;

namespace FluentCoding
{    
    public partial class Optional<O> : FluentContext<O>
    { 

        /// <summary>        
        /// Apply a set of actions to the subject (when this is not null)
        /// Then return the subject        
        /// </summary>
        /// <param name="doOnSubject"></param>
        /// <returns></returns>
        public Optional<O> DoOptional(params Action<O>[] doOnSubject)
        {
            if (IsSome())
            {
                foreach (var doOnSbj in doOnSubject)
                    doOnSbj(Subject);
            }

            return this;
        }

        /// <summary>
        /// Apply an set of function to the subject  (when this is not null)
        /// Then return the subject
        /// </summary>
        /// <param name="doOnSubject"></param>
        /// <returns></returns>
        public Optional<O> DoOptional(params Func<O, O>[] doOnSubject)
        {
            if (IsSome())
            {
                foreach (var doOnSbj in doOnSubject)
                    doOnSbj(Subject);
            }

            return this;
        }
    }
}
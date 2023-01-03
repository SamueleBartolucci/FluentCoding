using System;

namespace FluentCoding
{
    public static class DoExtensions
    {
        public static T Do<T>(this T _, Func<T, T> doOnSubject, bool applyWhenSubjectIsNullOrEquivalent = false) 
            => !_.IsNullOrEquivalent() || applyWhenSubjectIsNullOrEquivalent ? doOnSubject(_) : _;

        public static T Do<T>(this T _, Action<T> doOnSubject, bool applyWhenSubjectIsNullOrEquivalent = false)
        {
            if (!_.IsNullOrEquivalent() || applyWhenSubjectIsNullOrEquivalent) 
                doOnSubject(_);

            return _;
        }

        public static T Do<T>(this T _, params Action<T>[] doOnSubject)
        {
            if (!_.IsNullOrEquivalent())
            {
                foreach (var doOnSbj in doOnSubject)
                    doOnSbj(_);
            }

            return _;
        }
    }
}
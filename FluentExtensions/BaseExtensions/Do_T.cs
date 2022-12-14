using System;

namespace FluentCoding
{
    public static class Do_T
    {
        public static T Do<T>(this T _, Func<T, T> doOnSubject) => _.IsNullOrDefault() ? _ : doOnSubject(_);

        public static T Do<T>(this T _, Action<T> doOnSubject) 
        {
            if (!_.IsNullOrDefault()) doOnSubject(_);
            return _;
        }
    }
}
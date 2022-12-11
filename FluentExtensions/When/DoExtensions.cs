using System;

namespace FluentExtensions
{
    public static class DoExtensions
    {

        //public static T TouchWhen<T>(this T _, Func<T, bool> whenTrue, Action<T> @do)
        //    => whenTrue(_) ? _.Touch(@do) : _;
        //public static T TouchWhen<T>(this T _, Func<bool> whenTrue, Action<T> @do)
        //    => whenTrue() ? _.Touch(@do) : _;

        //public static T TouchWhen<T>(this T _, Func<T, bool> whenTrue, Func<T, T> @do)
        //  => whenTrue(_) ? _.Touch(@do) : _;


        //public static T TouchWhen<T>(this T _, Func<bool> whenTrue, Func<T, T> @do)
        //    => whenTrue() ? _.Touch(@do) : _;


        //public static T DoWhen<T>(this T _, Func<bool> whenTrue, Action<T> @do) where T : class
        //    => whenTrue() ? _.Touch(@do) : _;

        public static T Do<T>(this T _, Func<T, T> applyDo) 
            => _.IsNullOrDefault() ? _ : applyDo(_);

        public static T Do<T>(this T _, Action<T> applyDo)
        {
            if (!_.IsNullOrDefault()) applyDo(_);
            return _;
        }
    }
}
using System;

namespace FluentExtensions
{
    public static class IsNullOrDefaultExtensions
    {        
        public static bool IsNullOrDefault<T>(this T @this) => @this.IsNullOrDefault(true);
        public static bool IsNullOrDefault<T>(this T @this, bool trimWhenString)
        {
            // deal with normal scenarios
            if (@this == null)
                return true;

            //avoid to return true when is the first enum value
            if (@this is Enum)
                return false;

            //deal with strings
            if (typeof(T).IsEquivalentTo(typeof(string)))
                return trimWhenString ? 
                        string.IsNullOrEmpty((@this as string).Trim()) : 
                        string.IsNullOrEmpty(@this as string);

            if (object.Equals(@this, default(T)))
                return true;

            // deal with non-null nullables
            Type methodType = typeof(T);
            if (Nullable.GetUnderlyingType(methodType) != null)
                return false;

            // deal with boxed value types
            Type argumentType = @this.GetType();
            if (argumentType.IsValueType && argumentType != methodType)
                return Activator.CreateInstance(@this.GetType()).Equals(@this);

            return false;
        }
    }
}
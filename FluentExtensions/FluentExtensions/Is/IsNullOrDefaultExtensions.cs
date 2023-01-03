using System;

namespace FluentCoding
{
    public static class IsNullOrDefaultExtensions
    {

        public static bool IsNullOrEquivalent<T>(this T @this, Action<IsNullOptions> setupCustomOptions = null)
        {
            var nullCheckOptions = new IsNullOptions();
            if(setupCustomOptions != null) 
                setupCustomOptions(nullCheckOptions);

            return @this.IsNullOrEquivalent(nullCheckOptions);
        }

        public static bool IsNullOrEquivalent<T>(this T @this, IsNullOptions nullCheckOptions)
        {
            // deal with normal scenarios
            if (@this == null)
                return true;

            //deal with strings
            if (typeof(T).IsEquivalentTo(typeof(string)))
            {

                if (nullCheckOptions.EmptyOrWhiteSpacesIsNull)
                    return string.IsNullOrWhiteSpace(@this as string);

                if (nullCheckOptions.EmptyStringIsNull)
                    return string.IsNullOrEmpty(@this as string);

                return false;
            }

            //// deal with non-null nullables
            //Type methodType = typeof(T);            
            //if (Nullable.GetUnderlyingType(methodType) != null)
            //    return false;

            //// deal with boxed value types
            //Type argumentType = @this.GetType();
            //if (argumentType.IsValueType && argumentType != methodType)
            //    return Activator.CreateInstance(@this.GetType()).Equals(@this);

            return false;
        }
    }
}
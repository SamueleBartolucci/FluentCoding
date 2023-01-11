using System;

namespace FluentCoding
{
    public static class IsNullOrEquivalentExtensions
    {
        /// <summary>
        /// Check if an object is null or an equivalent state
        /// By default String.Empty is equivalent to null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="setupCustomOptions"></param>
        /// <returns></returns>
        public static bool IsNullOrEquivalent<T>(this T @this, Action<IsNullOptions> setupCustomOptions = null)
        {
            //Temporary IF to speed up the check.
            //Currently only the string type has custom options for null check            
            if (typeof(T).IsEquivalentTo(typeof(string)))
            {
                var nullCheckOptions = new IsNullOptions();
                if (setupCustomOptions != null)
                    setupCustomOptions(nullCheckOptions);

                return @this.IsNullOrEquivalent(nullCheckOptions);
            }

            //all the other is a direct  check
            return @this == null;
        }

        /// <summary>
        /// Check if an object is null or an equivalent state
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="nullCheckOptions"></param>
        /// <returns></returns>
        public static bool IsNullOrEquivalent<T>(this T @this, IsNullOptions nullCheckOptions)
        {
            // deal with normal scenarios
            if (@this == null)
                return true;

            //deal with strings
            if (typeof(T).IsEquivalentTo(typeof(string)))
            {

                if (nullCheckOptions.StringIsNullWhen == StringIsNullWhenEnum.NullOrEmptyOrWhiteSpaces)
                    return string.IsNullOrWhiteSpace(@this as string);

                if (nullCheckOptions.StringIsNullWhen == StringIsNullWhenEnum.NullOrEmpty)
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